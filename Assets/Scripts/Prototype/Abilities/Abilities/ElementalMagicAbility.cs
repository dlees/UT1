using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalMagicAbility : Ability {

    private int mpCost ;
    public int fireAffinityIncrement;
    public int windAffinityIncrement;

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

		// TODO: Find a way to get the error message shown without duping code.
		if (performer.stats.mp.current < mpCost)
		{
			Debug.Log("Not enough MP!");
		}

		if (!isAbilityPerformable()) {
			return;
		}

        performer.stats.mp.current -= mpCost;

        foreach (Combatant target in targets) {
            float damage = multiplier * performer.stats.mag +
                 fireAffinityIncrement * (int)arena.fireElementalAffinity.current +
                 windAffinityIncrement * (int)arena.windElementalAffinity.current;

            target.stats.hp.current -= (int) damage;
            Debug.Log(performer.name + " casts " + name + " on " + target.name + " for damage " + damage);
        }

        arena.fireElementalAffinity.current += fireAffinityIncrement;
        arena.windElementalAffinity.current += windAffinityIncrement;

	}

	private bool isAbilityPerformable() {
		return performer.stats.hp.current > 0 && performer.stats.mp.current >= mpCost;

	}

    public override Ability getSkillChain(Ability ability) {
        if (ability.GetType() == typeof(ElementalMagicAbility)) {
            ElementalMagicAbility ability2 = (ElementalMagicAbility) ability;


            if (fireAffinityIncrement + ability2.fireAffinityIncrement > 0 && windAffinityIncrement + ability2.windAffinityIncrement > 0) {
                return AbilityFactory.createSkillChain("Lightning", arena, targets);
            } else if (fireAffinityIncrement + ability2.fireAffinityIncrement < 0 && windAffinityIncrement + ability2.windAffinityIncrement > 0) {
                return AbilityFactory.createSkillChain("Ice", arena, targets);
            } else if (fireAffinityIncrement + ability2.fireAffinityIncrement < 0 && windAffinityIncrement + ability2.windAffinityIncrement < 0) {
                return AbilityFactory.createSkillChain("Wood", arena, targets);
            } else if (fireAffinityIncrement + ability2.fireAffinityIncrement > 0 && windAffinityIncrement + ability2.windAffinityIncrement < 0) {
                return AbilityFactory.createSkillChain("Lava", arena, targets);
            }
        }
        return null;
    }
}
