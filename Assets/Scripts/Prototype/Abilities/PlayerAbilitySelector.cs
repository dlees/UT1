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
                if (menuItemSelector.selectedString != null)
                {
                    selectedAbility = menuItemSelector.selectedString;
                    
                    List<string> enemyNames = new List<string>();
                    foreach (Combatant enemy in enemies.combatants)
                    {
                        enemyNames.Add(enemy.CombatantName);
                    }

                    menuListLoader.loadMenu(enemyNames);

                    state = "waitingForTarget";
                }
                break;

           case "waitingForTarget" :
                if (menuItemSelector.selectedString != null)
                {
                    string selectedTarget = menuItemSelector.selectedString;

                    List<Combatant> selectedTargets = new List<Combatant>();

                    selectedTargets.Add(enemies.nameToCombatant[selectedTarget]);

				    state = "start";
				    return abilityFactory.createAbility (selectedAbility, performer, selectedTargets);
			    }
                break;

		    default:
                break;
        }
        return null;
	}

}
