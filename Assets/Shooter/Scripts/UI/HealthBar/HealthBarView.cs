using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter.UI
{
    internal interface IHealthBarView
    {
        void Init(int maxHealth);
        void GenerateHealth(int count);
        void UpdateHealthBar(int currentHealth);
    }

    internal class HealthBarView : MonoBehaviour, IHealthBarView
    {
        [SerializeField] private RectTransform _healthPlacement;
        [SerializeField] private Sprite _helthEmptySprite;
        [SerializeField] private Sprite _helthFullSprite;
        [SerializeField] private Image _healthItemPrefab;

        private List<Image> _healthsImage;

        private int _maxHealth;

        private void Awake()
        {
            _healthsImage = new List<Image>();
        }

        public void Init(int maxHealth)
        {
            if (!_healthItemPrefab)
                throw new ArgumentNullException(nameof(_healthItemPrefab));

            _maxHealth = maxHealth;

            GenerateHealth(_maxHealth);
        }

        public void GenerateHealth(int count)
        {
            for(int i = 0; i < count; i++)
            {
               Image newHealtPoint = Instantiate(_healthItemPrefab, _healthPlacement, false);
                _healthsImage.Add(newHealtPoint);
            }
        }

        public void UpdateHealthBar(int _currentHealth)
        {
            if (_healthsImage == null) return;

            for (int i = 0; i < _maxHealth; i++)
            {
                if (i > _currentHealth - 1)
                {
                    _healthsImage[i].sprite = _helthEmptySprite;
                }
                else
                {
                    _healthsImage[i].sprite = _helthFullSprite;
                }
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(_healthPlacement);
        }
    }
}
