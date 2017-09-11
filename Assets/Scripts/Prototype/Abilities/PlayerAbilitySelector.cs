using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilitySelector : AbilitySelector {

	public AbilityFactory abilityFactory;

	public Faction allies;	
	public Faction enemies;

	public MenuListLoader menuListLoader;
	public MenuItemSelector menuItemSelector;
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

			state = "waiting";
			return null;


		case "waiting":
			if (selectedAbility != null) {
				state = "start";
				return abilityFactory.createAbility (selectedAbility, performer, enemies.combatants);
			}
			return null;

		default:
			return null;
		}
	}

}
