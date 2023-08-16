using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics {
    public class GoToLevelTwoZone : MonoBehaviour
        {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredGoToLevelTwoZone>();
                ev.goToLevelTwoZone = this;
            }
        }
    }
}
