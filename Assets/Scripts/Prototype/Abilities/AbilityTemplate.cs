using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTemplate {

	public bool isCombatantTargetable(Combatant combatant) {
		return combatant.stats.hp.current > 0;

	}


}
