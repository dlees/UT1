using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability {

	public abstract void perform();

    public virtual Ability getSkillChain(Ability ability) { return null; }

}
