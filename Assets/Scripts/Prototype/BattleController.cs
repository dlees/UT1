using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour {

	public List<Faction> factions;

    private Queue<Ability> abilityQueue;
    private List<Ability> abilitiesInTurn;
	private Queue<Combatant> selectorQueue;

	private string state = "setupTurn";

	/// <summary>
	///  Choosing state
	/// </summary>
	private Combatant currentCombatantSelection = null;

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
						if (combatantCanTakeTurn(combatant)) {
							selectorQueue.Enqueue (combatant);
						}
				    }
			    }
                abilitiesInTurn = new List<Ability>();
			    state = "choose";
			    break;

		    case "choose":
			    if (selectorQueue.Count > 0) {
				    currentCombatantSelection = selectorQueue.Dequeue ();
				    state = "waitForSelection";

			    } else {
				    state = "calculateTurn";
			    }

			    break;

		    case "waitForSelection":

			    Ability selectedAbility = currentCombatantSelection.abilitySelector.selectAbility (currentCombatantSelection);

			    if (selectedAbility != null) {
				    abilitiesInTurn.Add(selectedAbility);
				    state = "choose";
			    }

			    break;

            case "calculateTurn":

                foreach (Ability ability in abilitiesInTurn)
                {
                    // can 4 people skill chain at once?
                    // can enemies skill chain with allies?
                    // for now let's keep it simple with just elements

                    abilityQueue.Enqueue(ability);
                }

                state = "act";
                break;

		    case "act":

                Ability lastAbility = null;
			    while (abilityQueue.Count > 0) {

				    Ability ability = abilityQueue.Dequeue ();
                    
                    ability.perform ();

                    if (lastAbility != null) {
                        Debug.Log("CheckSkillchain");
                        Ability skillChain = ability.getSkillChain(lastAbility);
                        if (skillChain != null) {
                            skillChain.perform();
                        }
                    }

                    lastAbility = ability;

                    if (isBattleLost()) {
                        state = "battleLost";
                        return;
                    }
                    if (isBattleWon()) {
                        state = "battleWon";
                        return;
                    }

			    }
			    state = "setupTurn";
			    break;

            case "battleLost":
                Debug.Log("Battle Lost!");
                break;

            case "battleWon":
                Debug.Log("Battle Won!");
                break;
		}
	}

    public bool isBattleLost() {
        foreach (Combatant combatant in factions[0].combatants) {
            if (combatant.stats.hp.current != 0) {
                return false;
            }
        }
        return true;
    }

    public bool isBattleWon() {
        foreach (Combatant combatant in factions[1].combatants) {
            if (combatant.stats.hp.current != 0) {
                return false;
            }
        }
        return true;
    }

	public bool combatantCanTakeTurn(Combatant combatant) {
		return combatant.stats.hp.current > 0;
	}

}
