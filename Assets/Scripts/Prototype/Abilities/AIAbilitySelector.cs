using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAbilitySelector : AbilitySelector {

	public AbilityFactory abilityFactory;
	public Faction allies;
	public Faction enemies;

	public override Ability selectAbility (Combatant performer) {

		return abilityFactory.createAbility ("Attack", performer, enemies.combatants);
	}

}

