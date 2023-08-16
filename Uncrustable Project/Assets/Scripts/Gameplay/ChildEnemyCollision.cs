using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

public class ChildEnemyCollision : Simulation.Event<ChildEnemyCollision>
{
    public ChildController child;
    public EnemyController witch;

    PlatformerModel model = Simulation.GetModel<PlatformerModel>();

    public override void Execute(){
        child.CaughtByWitch();
        Debug.Log("Child eaten! It was tragic.");
        AudioSource.PlayClipAtPoint(witch.nomnomnom, witch.transform.position);

        witch.ResetMovementSpeed();
        witch.WaitForPreyToRun();
    }
}
