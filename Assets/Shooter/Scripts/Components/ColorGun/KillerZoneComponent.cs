using Shooter.UI;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    internal class KillerZoneComponent : MonoBehaviour
    {
        [SerializeField] float killerZoneRadius;
        [SerializeField] CircleCollider2D killerZoneTrigger;
        AmmoController _ammoController;
        HealthController _healthController;
        ScoreController _scoreController;

        public void Init(
            AmmoController ammoController, 
            HealthController healthController,
            ScoreController scoreController)
        {
            killerZoneTrigger.radius = killerZoneRadius;
            _ammoController = ammoController;
            _healthController = healthController;
            _scoreController = scoreController;
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
                    _scoreController.IncreaseScoreValue();
                }
                else
                {
                    explosive.Damage();
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
