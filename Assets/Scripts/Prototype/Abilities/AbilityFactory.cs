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
                return new ElementalMagicAbility(performer, targets[0], arena, 5, 1, 0, "Fire");
            case "Wind":
                return new ElementalMagicAbility(performer, targets[0], arena, 5, 0, 1, "Wind");
            case "Water":
                return new ElementalMagicAbility(performer, targets[0], arena, 5, -1, 0, "Water");
            case "Earth":
                return new ElementalMagicAbility(performer, targets[0], arena, 5, 0, -1, "Earth");
		}
	
		throw new UnityException (name + " is not an ability.");
	}

}
