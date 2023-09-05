using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void PlayerTestSimplePasses()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<PlayerController>();


    }
}
