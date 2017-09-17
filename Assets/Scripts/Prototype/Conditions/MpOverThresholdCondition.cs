using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpOverThresholdCondition : CombatantCondition {

	private int mpCost;

	public MpOverThresholdCondition(int mpCost) {
		this.mpCost = mpCost;
	}

	public override bool isValid(Combatant combatant) {
		return combatant.stats.mp.current > mpCost;
	}
}
