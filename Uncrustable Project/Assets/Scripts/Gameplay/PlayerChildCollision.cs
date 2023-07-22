using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
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
        }
    }
}