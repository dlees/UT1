using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalMagicSkillChain : Ability {

    private int fireAffinity;
    private int windAffinity;
 
    //formula maybe?

    private List<Combatant> targets;
    private Arena arena;

    private string name;

    public ElementalMagicSkillChain(List<Combatant> targets, Arena arena, int fireAffinity, int windAffinity, string name) {
        this.targets = targets;
        this.arena = arena;
        this.fireAffinity = fireAffinity;
        this.windAffinity = windAffinity;
        this.name = name;
	}

	public override void perform() {

        foreach (Combatant target in targets) {
            float damage = 2 +
                 fireAffinity * (int)arena.fireElementalAffinity.current +
                 windAffinity * (int)arena.windElementalAffinity.current;

            target.stats.hp.current -= (int)damage;

            Debug.Log("The environment spawns " + name + " on " + target.name + " for damage " + damage);
        }
	}

}
