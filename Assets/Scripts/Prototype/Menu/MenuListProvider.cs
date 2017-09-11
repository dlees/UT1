using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuListProvider : MonoBehaviour {

	public abstract List<string> getItems ();
}
