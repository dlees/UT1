using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAliveCondition : CombatantCondition {

	public override bool isValid(Combatant combatant) {
		return combatant.stats.hp.current > 0;
	}
}
