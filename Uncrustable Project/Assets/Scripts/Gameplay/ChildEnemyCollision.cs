using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

public class ChildEnemyCollision : Simulation.Event<ChildEnemyCollision>
{
    public ChildController child;
    public EnemyController enemy;

    PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    // Start is called before the first frame update
    public override void Execute(){
        
    }
}
