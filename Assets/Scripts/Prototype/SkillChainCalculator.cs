using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChainCalculator : MonoBehaviour {

    public Arena arena;
    public AbilityFactory abilityFactory;

    public Ability getSkillChain(List<Ability> abilities)
    {
        Combatant performer = null;
        List<Combatant> targets = null;

        if (arena.fireElementalAffinity.current == arena.windElementalAffinity.current  && arena.fireElementalAffinity.current > 0)
        {
            return abilityFactory.createAbility("Lightning", performer, targets);
        }
        if (arena.fireElementalAffinity.current == arena.windElementalAffinity.current && arena.fireElementalAffinity.current < 0)
        {
            return abilityFactory.createAbility("Wood", performer, targets);
        }
        if (arena.fireElementalAffinity.current == -1 * arena.windElementalAffinity.current && arena.fireElementalAffinity.current > 0)
        {
            return abilityFactory.createAbility("Lava", performer, targets);
        }
        if (arena.fireElementalAffinity.current == -1 * arena.windElementalAffinity.current && arena.fireElementalAffinity.current > 0)
        {
            return abilityFactory.createAbility("Ice", performer, targets);
        }
        return null;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
