using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFactory : MonoBehaviour {

	public Arena arena;

	public Ability createAbility (string name, Combatant performer, List<Combatant> targets) {
	
		switch (name) {
		case "Attack":
			return new AttackAbility (performer, targets[0]);

		}
	
		throw new UnityException (name + " is not an ability.");
	}

}
