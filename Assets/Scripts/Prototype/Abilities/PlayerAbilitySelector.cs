using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilitySelector : AbilitySelector {

	public AbilityFactory abilityFactory;

	public Faction allies;	
	public Faction enemies;

	public MenuListLoader menuListLoader;
	public StringMenuItemSelector menuItemSelector;
	public MenuListProvider menuListProvider;

	public Text menuTitleText;

    private Faction selectedFaction;


	public string selectedAbility;
	private string state = "start";

	public override Ability selectAbility (Combatant performer) {
		switch (state) {
		    case "start":
			    selectedAbility = null;

			    menuTitleText.text = performer.CombatantName;

			    menuListLoader.menuListProvider = menuListProvider;
			    menuListLoader.menuItemSelector = menuItemSelector;
			    menuListLoader.loadMenu ();

                state = "waitingForAbility";
                break;


		    case "waitingForAbility":
                if (menuItemSelector.selectedString != null) {

                    selectedAbility = menuItemSelector.selectedString;

                    // TODO: The combatants we load need to be based off the ability. 
                    // Cure defaults to party (but can switch to enemy)
                    // ALL isn't for all abilities

                    loadMenuWithTargets(enemies, "Enemies");

                    state = "waitingForTarget";
                }
                break;

            case "selectAlly":

                    // TODO: The combatants we load need to be based off the ability. 
                    // Cure defaults to party (but can switch to enemy)
                    // ALL isn't for all abilities

                    loadMenuWithTargets(allies, "Allies");

                    state = "waitingForTarget";
                break;

           case "waitingForTarget" :
                if (menuItemSelector.selectedString != null) {
                    string selectedTarget = menuItemSelector.selectedString;

                    List<Combatant> selectedTargets = new List<Combatant>();

                    switch (selectedTarget) {

                        case "Ally":
                            state = "selectAlly";
                            break;

                        case "ALL Enemies":
                            selectedTargets = enemies.combatants;
				            state = "start";
				            return abilityFactory.createAbility (selectedAbility, performer, selectedTargets);

                        case "ALL Allies":
                            selectedTargets = allies.combatants;
				            state = "start";
				            return abilityFactory.createAbility (selectedAbility, performer, selectedTargets);

                        default:
                            selectedTargets.Add(selectedFaction.nameToCombatant[selectedTarget]);
				            state = "start";
				            return abilityFactory.createAbility (selectedAbility, performer, selectedTargets);                            
                    }

			    }
                break;

		    default:
                break;
        }
        return null;
	}

    private void loadMenuWithTargets(Faction faction, string factionName) {
        List<string> names = new List<string>();
		foreach (Combatant target in faction.combatants) {
			if (abilityFactory.getTargetableConditionsForAbility (selectedAbility).isValid(target)) {
				names.Add (target.CombatantName);
			}
		}

        names.Add("ALL " + factionName);

        // TOOD: UH ho, why are we putting this in all factions?
        names.Add("Ally");
        
        menuListLoader.loadMenu(names);

        selectedFaction = faction;
    }

}
