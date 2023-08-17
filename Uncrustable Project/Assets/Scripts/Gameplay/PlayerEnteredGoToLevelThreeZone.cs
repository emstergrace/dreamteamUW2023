using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{

    public class PlayerEnteredGoToLevelThreeZone: Simulation.Event<PlayerEnteredGoToLevelThreeZone>
    {
        public GoToLevelThreeZone goToLevelThreeZone;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            model.player.controlEnabled = false;
            SceneManager.LoadScene("Levels/Scenes/level3");
        }
    }
}
