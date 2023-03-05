using Shooter.UI;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class KillerZoneComponent : MonoBehaviour
    {
        [SerializeField] float killerZoneRadius;
        [SerializeField] CircleCollider2D killerZoneTrigger;
        AmmoController _ammoController;
        HealthController _healthController;

        public void Init(AmmoController ammoController, HealthController healthController)
        {
            killerZoneTrigger.radius = killerZoneRadius;
            _ammoController = ammoController;
            _healthController = healthController;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            var explosive = collision.GetComponent<IExplosive>();
            if (explosive != null)
            {
                if (explosive.IsExploding)
                {
                    explosive.Explode();
                    _ammoController.AddEnemyAmmo();
                }
                else
                {
                    _healthController.DecreaseHealth();
                }
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, killerZoneRadius);
        }
    }
}
