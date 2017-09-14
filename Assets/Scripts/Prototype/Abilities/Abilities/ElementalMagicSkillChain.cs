using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalMagicSkillChain : Ability {

    private int fireAffinity;
    private int windAffinity;
 
    //formula maybe?

	private Combatant target;
    private Arena arena;

    private string name;

    public ElementalMagicSkillChain(Combatant target, Arena arena, int fireAffinity, int windAffinity, string name)
    {
		this.target = target;
        this.arena = arena;
        this.fireAffinity = fireAffinity;
        this.windAffinity = windAffinity;
        this.name = name;
	}

	public override void perform() {
        int damage = 
            fireAffinity * (int) arena.fireElementalAffinity.current + 
            windAffinity * (int) arena.windElementalAffinity.current;
        
		target.stats.curHP.current -= damage;

        arena.fireElementalAffinity.current += fireAffinity;
        arena.windElementalAffinity.current += windAffinity;

		Debug.Log("The environment spawns " + name + " on " + target.name + " for damage " + damage);
	}

}
