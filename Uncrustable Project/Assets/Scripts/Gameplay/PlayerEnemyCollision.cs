using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
    {
        public EnemyController witch;
        public PlayerController player;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            Debug.Log("Player hit by witch");
            var child = player.PopChildFromList();
            if (child is not null){
                var childController = child.GetComponent<ChildController>();
                childController.CaughtByWitch();
                Debug.Log("Child eaten while following the player.");
            }
            else
            {
                Schedule<PlayerDeath>();
            }

            witch.GetComponent<EnemyController>().ResetMovementSpeed();
        }
    }
}