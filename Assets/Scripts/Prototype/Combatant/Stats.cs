using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	public RangeValue hp;
	public RangeValue mp;
	public int str;
	public int mag;
	public int def;
	public int magdef;
	public int agl;

	private Dictionary<string, RangeValue> statNameToValueMap;

	void Start() {
		statNameToValueMap ["hp"] = hp;
		statNameToValueMap ["mp"] = mp;
		statNameToValueMap ["str"] = createRangeValue (str);
		statNameToValueMap ["mag"] = createRangeValue (mag);
		statNameToValueMap ["def"] = createRangeValue (def);
		statNameToValueMap ["mdf"] = createRangeValue (magdef);
		statNameToValueMap ["agl"] = createRangeValue (agl);
	}


	public RangeValue createRangeValue(int startingValue) {
		RangeValue rangeValue = GameObject.Instantiate (hp);
		rangeValue.max = 255;
		rangeValue.current = startingValue;
		return rangeValue;
	
	}

	public RangeValue getStat(string statName) {
		return statNameToValueMap [statName];
	}
}
