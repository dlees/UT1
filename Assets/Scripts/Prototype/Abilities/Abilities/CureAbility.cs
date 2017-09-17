using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureAbility : Ability {

    private int mpCost ;

	private Combatant performer;
	private List<Combatant> targets;
    private float multiplier;

    private string name;

    public CureAbility(Combatant performer, List<Combatant> targets, int mpCost, float multiplier, string name)
    {
		this.performer = performer;
		this.targets = targets;
        this.mpCost = mpCost;
        this.name = name;
        this.multiplier = multiplier;
	}

	public override void perform() {
        if (performer.stats.mp.current < mpCost)
        {
            Debug.Log("Not enough MP!");
            return;
        }
        performer.stats.mp.current -= mpCost;

        foreach (Combatant target in targets) {
            float healAmount = multiplier * performer.stats.mag;

            target.stats.hp.current += (int) healAmount;
            
            Debug.Log(performer.name + " casts " + name + " on " + target.name + " for " + healAmount);
        }
	}

}