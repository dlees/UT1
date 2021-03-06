﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFactory : MonoBehaviour {

	public Arena arena;

	private IsAliveCondition isAliveCondition = new IsAliveCondition ();

	public CombatantCondition getTargetableConditionsForAbility(string abilityName) {
	
		return isAliveCondition;
		/*
		switch (name) {
		case "Attack":
			return new AttackAbility (performer, targets [0]);
		case "Fire":
			return new ElementalMagicAbility (performer, targets, arena, 5, 1, 0, getMultiplier (targets, 1), "Fire");
		case "Wind":
			return new ElementalMagicAbility (performer, targets, arena, 5, 0, 1, getMultiplier (targets, 1), "Wind");
		case "Water":
			return new ElementalMagicAbility (performer, targets, arena, 5, -1, 0, getMultiplier (targets, 1), "Water");
		case "Earth":
			return new ElementalMagicAbility (performer, targets, arena, 5, 0, -1, getMultiplier (targets, 1), "Earth");
		case "Lightning":
			return new ElementalMagicAbility (performer, targets, arena, 5, 1, 1, getMultiplier (targets, 1), "Lightning");
		case "Wood":
			return new ElementalMagicAbility (performer, targets, arena, 5, -1, -1, getMultiplier (targets, 1), "Wood");
		case "Lava":
			return new ElementalMagicAbility (performer, targets, arena, 5, 1, -1, getMultiplier (targets, 1), "Lava");
		case "Ice":
			return new ElementalMagicAbility (performer, targets, arena, 5, -1, 1, getMultiplier (targets, 1), "Ice");
		case "Cure":
			return new CureAbility (performer, targets, 5, getMultiplier (targets, 1), "Cure");
		}
		throw new UnityException (name + " is not an ability.");*/

	}

	public Ability createAbility (string name, Combatant performer, List<Combatant> targets) {
	
		switch (name) {
		    case "Attack":
			    return new AttackAbility (performer, targets[0]);
            case "Fire":
                return new ElementalMagicAbility(performer, targets, arena, 5, 1, 0, getMultiplier(targets, 1), "Fire");
            case "Wind":
                return new ElementalMagicAbility(performer, targets, arena, 5, 0, 1, getMultiplier(targets, 1), "Wind");
            case "Water":
                return new ElementalMagicAbility(performer, targets, arena, 5, -1, 0, getMultiplier(targets, 1), "Water");
            case "Earth":
                return new ElementalMagicAbility(performer, targets, arena, 5, 0, -1, getMultiplier(targets, 1), "Earth");
            case "Lightning":
                return new ElementalMagicAbility(performer, targets, arena, 5, 1, 1, getMultiplier(targets, 1), "Lightning");
            case "Wood":
                return new ElementalMagicAbility(performer, targets, arena, 5, -1, -1, getMultiplier(targets, 1), "Wood");
            case "Lava":
                return new ElementalMagicAbility(performer, targets, arena, 5, 1, -1, getMultiplier(targets, 1), "Lava");
            case "Ice":
                return new ElementalMagicAbility(performer, targets, arena, 5, -1, 1, getMultiplier(targets, 1), "Ice");
            case "Cure":
                return new CureAbility(performer, targets, 5, getMultiplier(targets, 1), "Cure");
		}
	
		throw new UnityException (name + " is not an ability.");
	}

    public static  Ability createSkillChain(string name, Arena arena, List<Combatant> targets) {

        switch (name) {
            case "Lightning":
                return new ElementalMagicSkillChain(targets, arena, 1, 1, "Lightning");
            case "Wood":
                return new ElementalMagicSkillChain(targets, arena, -1, -1, "Wood");
            case "Lava":
                return new ElementalMagicSkillChain(targets, arena, 1, -1,  "Lava");
            case "Ice":
                return new ElementalMagicSkillChain(targets, arena, -1, 1,  "Ice");
            
        }

        throw new UnityException(name + " is not an ability.");
    }

    private float getMultiplier(List<Combatant> targets, int level) {
        if (targets.Count == 1) {
            return 1.0f;
        }
        return 0.5f;
    } 

}
