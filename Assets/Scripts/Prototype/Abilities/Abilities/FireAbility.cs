using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility : Ability {

    // Put these into a template or just pass them in via constructor and let factory deal with it?
    private static int MP_COST = 5;
    private static int FIRE_AFINITY_INCREMENT = 1;
 
    //formula maybe?

	private Combatant performer;
	private Combatant target;
    private Arena arena;

    public FireAbility(Combatant performer, Combatant target, Arena arena)
    {
		this.performer = performer;
		this.target = target;
        this.arena = arena;
	}

	public override void perform() {
        if (performer.stats.curMP.current < MP_COST)
        {
            Debug.Log("Not enough MP!");
            return;
        }
        performer.stats.curMP.current -= MP_COST;

        int damage = performer.stats.mag + arena.fireElementalAffinity;
        
		target.stats.curHP.current -= damage;

        arena.fireElementalAffinity += 1;

		Debug.Log(performer.name + " casts fire on " + target.name + " for damage " + damage);
	}

}
