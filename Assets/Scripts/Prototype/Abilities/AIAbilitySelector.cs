using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAbilitySelector : AbilitySelector {

	public AbilityFactory abilityFactory;
	public Faction allies;
	public Faction enemies;

	public override Ability selectAbility (Combatant performer) {

        List<Combatant> chosenTargets = new List<Combatant>();

        List<Combatant> possibleTargets = new List<Combatant>();

        // TODO: we could pull this out into a filter and
        // Add the filter to the ability.
        foreach (Combatant target in enemies.combatants) {
            if (target.stats.hp.current > 0) {
                possibleTargets.Add(target);
            }
        }

        int chosenCombatant = Random.Range(0, possibleTargets.Count);

        chosenTargets.Add(possibleTargets[chosenCombatant]);

		return abilityFactory.createAbility ("Attack", performer, chosenTargets);
	}
}

