using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class NewEditModeTest {

	[Test]
	public void NewEditModeTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

    Dictionary<string, int> getStats(int HP, int MP, int str, int def) {
        Dictionary<string, int> stats = new Dictionary<string, int>();
        stats["hp"] = HP;
        stats["mp"] = MP;
        stats["str"] = str;
        stats["def"] = def;
        return stats;
    }


    [Test]
    public void dealMoreDamageToLessDefensiveEnemiesThanMoreDefensive() {
        Dictionary<string, int> performerStats = getStats(100, 100, 20, 20);
        Dictionary<string, int> strongerTargetStats = getStats(100, 100, 20, 20);
        Dictionary<string, int> weakerTargetStats = getStats(100, 100, 20, 10);

        int damageToStrongerTarget = getDamageForAttack(performerStats, strongerTargetStats);
        int damageToWeakerTarget = getDamageForAttack(performerStats, weakerTargetStats);

        Assert.IsTrue(damageToStrongerTarget < damageToWeakerTarget);
    }

    [Test]
    public void damageAtStrDifferencesAreSameProportion() {
        Dictionary<string, int> performer20Stats = getStats(100, 100, 20, 20);
        Dictionary<string, int> performer25Stats = getStats(100, 100, 25, 20);
        Dictionary<string, int> performer60Stats = getStats(100, 100, 60, 20);
        Dictionary<string, int> performer65Stats = getStats(100, 100, 65, 20);
        Dictionary<string, int> strongerTargetStats = getStats(100, 100, 20, 60);
        Dictionary<string, int> weakerTargetStats = getStats(100, 100, 20, 20);

        int damageWith20Str = getDamageForAttack(performer20Stats, weakerTargetStats);
        int damageWith25Str = getDamageForAttack(performer25Stats, weakerTargetStats);
        int damageWith60Str = getDamageForAttack(performer60Stats, strongerTargetStats);
        int damageWith65Str = getDamageForAttack(performer65Stats, strongerTargetStats);

        Assert.AreEqual((float) damageWith25Str / damageWith20Str, (float) damageWith65Str / damageWith60Str);
    }

    public int getDamageForAttack(Dictionary<string, int> performer, Dictionary<string, int> target) {
        return performer["str"] - target["def"];
    }

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator NewEditModeTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
