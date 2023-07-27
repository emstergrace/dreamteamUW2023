using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class PlayerChildCollision : Simulation.Event<PlayerChildCollision>
    {
        // Start is called before the first frame update
        public ChildController child;
        public PlayerController player;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            Debug.Log("Child Hit!");

            if (child.isCollected){
                return;
            }
            
            child.isCollected = true;

            if (player.follower != null){
                Debug.Log("Player Follower Not Null");
                var lastFollower = player.follower.GetComponent<ChildController>();

                while(lastFollower.follower != null){
                    lastFollower = lastFollower.follower.GetComponent<ChildController>();
                }
                Debug.Log("Child added to end of line");
                lastFollower.follower = child.gameObject;
                child.leader = lastFollower.gameObject;
            } else {
                Debug.Log("First child added");
                player.follower = child.gameObject;
                child.leader = player.gameObject;
            }
            
        }
    }
}