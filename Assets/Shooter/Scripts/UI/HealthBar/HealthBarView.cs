using TMPro;
using UnityEngine;

namespace Shooter.UI
{
    internal interface IHealthBarView
    {
        void Init(float maxHealth);
        void SetHealth(float amount);
    }

    internal class HealthBarView : MonoBehaviour, IHealthBarView
    {
        [SerializeField] private TMP_Text _health;

        private float _maxHealth;

        public void Init(float maxHealth)
        {
            _maxHealth = maxHealth;
            SetHealth(_maxHealth);
        }

        public void SetHealth(float amount)
        {
            if (amount < 0) amount = 0;
            float resultHealth = amount > _maxHealth ? _maxHealth : amount;

            _health.text = $"Player Health: {resultHealth}";
        }
    }
}
