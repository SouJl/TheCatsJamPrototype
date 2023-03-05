using Shooter.UI;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class KillerZoneComponent : MonoBehaviour
    {
        AmmoController _ammoController;
        HealthController _healthController;
        ScoreController _scoreController;

        public void Init(
            AmmoController ammoController,
            HealthController healthController,
            ScoreController scoreController)
        {
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
    }
}
