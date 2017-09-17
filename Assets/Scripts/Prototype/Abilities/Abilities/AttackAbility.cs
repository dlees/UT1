using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAbility : Ability {

	private Combatant performer;
	private Combatant target;

	public AttackAbility(Combatant performer, Combatant target) {
		this.performer = performer;
		this.target = target;
	}

	public override void perform() {
		int damage = performer.stats.str;

		target.stats.hp.current -= damage;
		Debug.Log(performer.name + " attacks " + target.name + " for damage " + damage);
	}

}
