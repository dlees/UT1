using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalMagicAbility : Ability {

    private int mpCost ;
    private int fireAffinityIncrement;
    private int windAffinityIncrement;
 
    //formula maybe?

	private Combatant performer;
	private Combatant target;
    private Arena arena;

    private string name;

    public ElementalMagicAbility(Combatant performer, Combatant target, Arena arena, int mpCost, int fireAffinity, int windAffinity, string name)
    {
		this.performer = performer;
		this.target = target;
        this.arena = arena;
        this.mpCost = mpCost;
        this.fireAffinityIncrement = fireAffinity;
        this.windAffinityIncrement = windAffinity;
        this.name = name;
	}

	public override void perform() {
        if (performer.stats.curMP.current < mpCost)
        {
            Debug.Log("Not enough MP!");
            return;
        }
        performer.stats.curMP.current -= mpCost;

        int damage = performer.stats.mag + 
            fireAffinityIncrement * (int) arena.fireElementalAffinity.current + 
            windAffinityIncrement * (int) arena.windElementalAffinity.current;
        
		target.stats.curHP.current -= damage;

        arena.fireElementalAffinity.current += fireAffinityIncrement;
        arena.windElementalAffinity.current += windAffinityIncrement;

		Debug.Log(performer.name + " casts " + name + " on " + target.name + " for damage " + damage);
	}

}
