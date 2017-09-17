using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatOverThresholdCondition : CombatantCondition {

	private string statName;
	private int threshold;

	public StatOverThresholdCondition(string statName, int threshold) {
		this.threshold = threshold;
		this.statName = statName;
	}

	public override bool isValid(Combatant combatant) {
		return combatant.stats.getStat(statName).current > threshold;
	}
}

