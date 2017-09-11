using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour {

	public List<Faction> factions;

	private Queue<Ability> abilityQueue;
	private Queue<Combatant> selectorQueue;

	private string state = "setupTurn";

	/// <summary>
	///  Choosing state
	/// </summary>
	private Combatant currentCombatantSelection = null;

	// Use this for initialization
	void Start () {
		abilityQueue = new Queue<Ability>();
		selectorQueue = new Queue<Combatant> ();
	}
	
	// Update is called once per frame
	void Update () {
		

		switch (state) {
		case "setupTurn":
			foreach (Faction faction in factions) {
				foreach (Combatant combatant in faction.combatants) {
					selectorQueue.Enqueue (combatant);
				}
			}
			state = "choose";
			break;

		case "choose":
			if (selectorQueue.Count > 0) {
				currentCombatantSelection = selectorQueue.Dequeue ();
				state = "waitForSelection";

			} else {
				state = "act";
			}

			break;

		case "waitForSelection":

			Ability selectedAbility = currentCombatantSelection.abilitySelector.selectAbility (currentCombatantSelection);

			if (selectedAbility != null) {
				abilityQueue.Enqueue (selectedAbility);
				state = "choose";
			}

			break;


		case "act":
			while (abilityQueue.Count > 0) {
				abilityQueue.Dequeue ().perform ();
			
			}
			state = "setupTurn";
			break;
		}

	}
}
