using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DirectionalTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void DirectionalTestSimplePasses()
    {
        Assert.AreEqual(4.4f,EnemyController.MAX_WITCH_SPEED);
    }
}
