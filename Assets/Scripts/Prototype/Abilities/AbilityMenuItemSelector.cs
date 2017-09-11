using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMenuItemSelector : MenuItemSelector {
	public PlayerAbilitySelector abilitySelector;

	public override void selectItem(string selectedItem) {
		abilitySelector.selectedAbility = selectedItem;
	}

}
