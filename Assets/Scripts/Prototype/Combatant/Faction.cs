using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faction : MonoBehaviour {
	public List<Combatant> combatants;

    public Dictionary<string, Combatant> nameToCombatant;
    public NonMonoStats stats;
    void Start()
    {
        nameToCombatant = new Dictionary<string, Combatant>();
        foreach (Combatant combatant in combatants)
        {
            nameToCombatant.Add(combatant.CombatantName, combatant);
        }
    }
}
