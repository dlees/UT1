using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityListProvider : MenuListProvider {
	public Combatant combatant;

	public override List<string> getItems() {
		return combatant.abilities;
	
	}
}
