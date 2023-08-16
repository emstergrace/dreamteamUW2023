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
            var numOfChildren = player.childrenFollowing.Count;
            if (numOfChildren > 0){
                var childGameObject = player.childrenFollowing[numOfChildren-1];
                player.childrenFollowing.RemoveAt(numOfChildren-1);

                var childController = childGameObject.GetComponent<ChildController>();
                childController.CaughtByWitch();
                Debug.Log("Child eaten! It was tragic.");
            }
            else
            {
                Schedule<PlayerDeath>();
            }

            witch.GetComponent<EnemyController>().ResetMovementSpeed();
        }
    }
}