using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalMagicAbility : Ability {

    private int mpCost ;
    private int fireAffinityIncrement;
    private int windAffinityIncrement;
 
    //formula maybe?

	private Combatant performer;
	private List<Combatant> targets;
    private Arena arena;
    private float multiplier;

    private string name;

    public ElementalMagicAbility(Combatant performer, List<Combatant> targets, Arena arena, int mpCost, int fireAffinity, int windAffinity, float multiplier, string name)
    {
		this.performer = performer;
		this.targets = targets;
        this.arena = arena;
        this.mpCost = mpCost;
        this.fireAffinityIncrement = fireAffinity;
        this.windAffinityIncrement = windAffinity;
        this.name = name;
        this.multiplier = multiplier;
	}

	public override void perform() {
        if (performer.stats.curMP.current < mpCost)
        {
            Debug.Log("Not enough MP!");
            return;
        }
        performer.stats.curMP.current -= mpCost;

        foreach (Combatant target in targets) {
            float damage = multiplier * performer.stats.mag +
                 fireAffinityIncrement * (int)arena.fireElementalAffinity.current +
                 windAffinityIncrement * (int)arena.windElementalAffinity.current;

            target.stats.curHP.current -= (int) damage;
            Debug.Log(performer.name + " casts " + name + " on " + target.name + " for damage " + damage);
        }

        arena.fireElementalAffinity.current += fireAffinityIncrement;
        arena.windElementalAffinity.current += windAffinityIncrement;

	}
}
