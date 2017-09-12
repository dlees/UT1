using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFactory : MonoBehaviour {

	public Arena arena;

	public Ability createAbility (string name, Combatant performer, List<Combatant> targets) {
	
		switch (name) {
		    case "Attack":
			    return new AttackAbility (performer, targets[0]);
            case "Fire":
                return new FireAbility(performer, targets[0], arena);
		}
	
		throw new UnityException (name + " is not an ability.");
	}

}
