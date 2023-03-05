using Shooter.UI;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class HealthPickupZoneComponent : MonoBehaviour
    {
        [SerializeField] float healthPickupZoneRadius;
        [SerializeField] CircleCollider2D healthPickupZoneTrigger;
        HealthController _healthController;

        public void Init(HealthController healthController)
        {
            healthPickupZoneTrigger.radius = healthPickupZoneRadius;
            _healthController = healthController;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            var health = collision.GetComponent<IHealth>();
            if (health != null)
            {
                _healthController.IncreaseHealth();
                health.gameObject.SetActive(false);
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, healthPickupZoneRadius);
        }
    }
}
