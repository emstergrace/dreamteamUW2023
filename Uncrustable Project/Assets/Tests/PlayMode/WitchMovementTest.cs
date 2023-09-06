using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.TestTools;

public class WitchMovementTest
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator WitchMovement()
    {
        /*var gameObject = new GameObject();
        var witch = gameObject.AddComponent<EnemyController>();
        witch.gameObject.transform.position = Vector3.zero;

        var player = gameObject.AddComponent<PlayerController>();
        player.transform.position = new Vector3(5, 0);


        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(1.5f);

        Assert.LessOrEqual(0, witch.Pause);*/

        yield return null;
    }
}
