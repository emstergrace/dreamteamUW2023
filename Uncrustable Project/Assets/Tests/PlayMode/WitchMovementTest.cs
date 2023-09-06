using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class WitchMovementTest
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator WitchMovement()
    {
        //var testScene = SceneManager.GetSceneByName("TestScene");
        var witchTestObject = new GameObject("Witch");
        //var witchTestObject = GameObject.Instantiate(new GameObject("Witch"));
        var childTestObject = new GameObject("Child");
        //var playerTestObject = GameObject.Instantiate(new GameObject("Child"));

        Debug.Log("Instantiate test object");
        witchTestObject.AddComponent<BoxCollider2D>();
        var witch = witchTestObject.AddComponent<EnemyController>();

        Debug.Log("add witch component");
        witch.gameObject.transform.position = Vector3.zero;
        Debug.Log("set witch position");

        childTestObject.AddComponent<Rigidbody2D>();
        childTestObject.AddComponent<BoxCollider2D>();
        var player = childTestObject.AddComponent<ChildController>();
        Debug.Log("set player object");
        player.transform.position = new Vector3(5, 0);
        Debug.Log("set player position");

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(1.5f);
        Debug.Log("yield for time");

        Assert.LessOrEqual(0, witch.Pause);
        Debug.Log("check pause");

        yield return null;
    }
}
