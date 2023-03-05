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
        void IncreaseHealth();
        void DecreaseHealth();
    }

    internal class HealthBarView : MonoBehaviour, IHealthBarView
    {
        [SerializeField] private RectTransform _healthPlacement;
        [SerializeField] private Sprite _helthEmptySprite;
        [SerializeField] private Sprite _helthFullSprite;
        [SerializeField] private Image _healthItemPrefab;

        private List<Image> _healthsImage;
        private int _maxHealth;
        private int _currentHealth;

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

        public void IncreaseHealth()
        {
            int resultHealth = _currentHealth + 1;
            _currentHealth = resultHealth > _maxHealth ? _maxHealth : resultHealth;

            UpdateHealthBar();
        }

        public void DecreaseHealth()
        {
            int resultHealth = _currentHealth - 1;
            _currentHealth = resultHealth < 0 ? 0 : resultHealth;

            UpdateHealthBar();
        }

        private void GenerateHealth(int count)
        {
            for(int i =0; i < count; i++)
            {
               Image newHealtPoint = Instantiate(_healthItemPrefab, _healthPlacement, false);
                _healthsImage.Add(newHealtPoint);
            }

            _currentHealth = _maxHealth;
        }

        private void UpdateHealthBar()
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
        }

        #region For UI Test

        [ContextMenu(nameof(AddHealth))]
        private void AddHealth() => IncreaseHealth();

        [ContextMenu(nameof(MinusOneHealt))]
        private void MinusOneHealt() => DecreaseHealth();

        #endregion
    }
}
