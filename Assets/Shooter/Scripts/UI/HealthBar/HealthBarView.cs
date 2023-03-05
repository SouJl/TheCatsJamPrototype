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
        void IncreaseHealth(int amount);
        void DecreaseHealth(int amount);
    }

    internal class HealthBarView : MonoBehaviour, IHealthBarView
    {
        [SerializeField] private RectTransform _healthPlacement;
        [SerializeField] private Sprite helthSprite;
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

            IncreaseHealth(_maxHealth);
        }

        public void IncreaseHealth(int amount)
        {
            if (amount < 0) amount = 0;       
            int resultHealth = _currentHealth + amount;
            _currentHealth = resultHealth > _maxHealth ? _maxHealth : resultHealth;

            UpdateHealthBar();
        }

        public void DecreaseHealth(int amount)
        {
            if (amount < 0) amount = 0;
            int resultHealth = _currentHealth - amount;
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
        }

        private void UpdateHealthBar()
        {
            if (_healthsImage == null) return;

            for (int i = 0; i < _maxHealth; i++)
            {
                if (i > _currentHealth - 1)
                {
                    _healthsImage[i].sprite = default;
                    _healthsImage[i].enabled = false;
                }
                else
                {
                    _healthsImage[i].sprite = helthSprite;
                    _healthsImage[i].enabled = true;
                }
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(_healthPlacement);
        }


        #region For UI Test

        [ContextMenu(nameof(AddOneHealth))]
        private void AddOneHealth() => IncreaseHealth(1);

        [ContextMenu(nameof(MinusOneHealt))]
        private void MinusOneHealt() => DecreaseHealth(1);
        
        #endregion

    }
}
