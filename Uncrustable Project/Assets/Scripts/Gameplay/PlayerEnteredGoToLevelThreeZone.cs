using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{

    public class PlayerEnteredGoToLevelTwoZone: Simulation.Event<PlayerEnteredGoToLevelTwoZone>
    {
        public GoToLevelTwoZone goToLevelTwoZone;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            model.player.controlEnabled = false;
            SceneManager.LoadScene("Levels/Scenes/level2");
        }
    }
}
