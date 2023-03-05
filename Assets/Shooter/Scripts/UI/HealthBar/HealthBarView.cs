using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter.UI
{
    internal interface IHealthBarView
    {
        event Action<int> onHealthChanged;

        void Init(int maxHealth);
        void DecreaseHealth();
    }

    internal class HealthBarView : MonoBehaviour, IHealthBarView
    {
        public event Action<int> onHealthChanged;

        [SerializeField] private RectTransform _healthPlacement;
        [SerializeField] private Sprite _helthEmptySprite;
        [SerializeField] private Sprite _helthFullSprite;
        [SerializeField] private HealthView _healthItemPrefab;

        private List<HealthView> _healths;
        private int _maxHealth;
        private int _currentHealth;

        private void Awake()
        {
            _healths = new List<HealthView>();
        }

        public void Init(int maxHealth)
        {
            _maxHealth = maxHealth;
            GenerateHealth(_maxHealth);
        }

        public void IncreaseHealth()
        {
            int resultHealth = _currentHealth + 1;
            _currentHealth = resultHealth > _maxHealth ? _maxHealth : resultHealth;

            UpdateHealthBar();
            onHealthChanged?.Invoke(_currentHealth);
        }

        public void DecreaseHealth()
        {
            int resultHealth = _currentHealth - 1;
            _currentHealth = resultHealth < 0 ? 0 : resultHealth;

            UpdateHealthBar();
            onHealthChanged?.Invoke(_currentHealth);
        }

        private void GenerateHealth(int count)
        {
            for(int i =0; i < count; i++)
            {
               HealthView healthView = Instantiate(_healthItemPrefab, _healthPlacement, false);
               healthView.SetSprite(_helthFullSprite);
               _healths.Add(healthView);
            }

            _currentHealth = _maxHealth;
        }

        private void UpdateHealthBar()
        {
            if (_healths == null) return;

            for (int i = 0; i < _maxHealth; i++)
            {
                if (i > _currentHealth - 1)
                {
                    _healths[i].SetSprite(_helthEmptySprite);
                }
                else
                {
                    _healths[i].SetSprite(_helthFullSprite);
                }
            }
        }

        #region For UI Test

        [ContextMenu(nameof(AddHealth))]
        private void AddHealth() => IncreaseHealth();

        [ContextMenu(nameof(MinusOneHealt))]
        private void MinusOneHealt() => DecreaseHealth();

        #endregion
    }
}
