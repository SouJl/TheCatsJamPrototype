using Shooter.UI;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class HealthPickupZoneComponent : MonoBehaviour
    {
        HealthController _healthController;

        public void Init(HealthController healthController)
        {
            _healthController = healthController;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            var health = collision.GetComponent<IHealth>();
            if (health != null)
            {
                _healthController.IncreaseHealth();
                health.Consume();
            }
        }
    }
}
