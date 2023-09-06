using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Platformer.Mechanics;

public class GameValuesTests
{
    [Test]
    public void WitchMaxSpeedTest()
    {
        var witch = new EnemyController();
        Assert.AreEqual(4.4f, witch.MAX_WITCH_SPEED);
    }

    [Test]
    public void WitchAcceleration() 
    {
        var witch = new EnemyController();
        Assert.AreEqual(4.4f, witch.MAX_WITCH_SPEED);
    }
}
