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
        void GenerateHealth(int count);
        void UpdateHealthBar(int currentHealth);
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

        private void Awake()
        {
            _healths = new List<HealthView>();
        }

        public void Init(int maxHealth)
        {
            _maxHealth = maxHealth;
            GenerateHealth(_maxHealth);
        }

        public void GenerateHealth(int count)
        {
            for(int i = 0; i < count; i++)
            {
               HealthView healthView = Instantiate(_healthItemPrefab, _healthPlacement, false);
               healthView.SetSprite(_helthFullSprite);
               _healths.Add(healthView);
            }
        }

        public void UpdateHealthBar(int _currentHealth)
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
    }
}
