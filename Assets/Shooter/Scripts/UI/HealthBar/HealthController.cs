using System;
using Shooter.Controllers;
using Shooter.Player;
using Shooter.Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Shooter.UI
{
    public class HealthController : IExecute
    {
        public event Action<int> onHealthChanged;

        private readonly string _viewPath = @"Prefabs/UI/Health/HealthBarView";
        private readonly string _configPath = @"Configs/Health/HealthConfig";

        private readonly IHealthBarView _view;
        readonly IHealthConfig _config;

        private int _maxHealth;
        private int _currentHealth;
        float _nextRechargeTime;
        HealthSpawner _healthSpawner;
        string _healthSpawnerPrefab = @"Prefabs/Health/HealthSpawner";


        public HealthController(Transform placeforUI)
        {
            _view = LoadView(placeforUI);
            _config = LoadConfig(_configPath);

            _maxHealth = _config.HealthPoints;
            _currentHealth = _maxHealth;
            _view.Init(_maxHealth);

            _healthSpawner = LoadSpawnerView();
            _nextRechargeTime = 0f;

            _view.onHealthChanged += (health) => onHealthChanged?.Invoke(health);
        }

        private IHealthBarView LoadView(Transform placeforUI)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeforUI, false);
            return objectView.GetComponent<HealthBarView>();
        }

        private HealthSpawner LoadSpawnerView()
        {
            var spawner = Object.Instantiate(ResourceLoader.LoadPrefab(_healthSpawnerPrefab)).GetComponent<HealthSpawner>();
            spawner.Init(_config.LifeTime);
            return spawner;
        }

        public void IncreaseHealth()
        {
            int resultHealth = _currentHealth + 1;
            _currentHealth = resultHealth > _maxHealth ? _maxHealth : resultHealth;

            _view.UpdateHealthBar(_currentHealth);
            onHealthChanged?.Invoke(_currentHealth);
        }

        public void DecreaseHealth()
        {
            int resultHealth = _currentHealth - 1;
            _currentHealth = resultHealth < 0 ? 0 : resultHealth;

            _view.UpdateHealthBar(_currentHealth);
            onHealthChanged?.Invoke(_currentHealth);
        }

        private IHealthConfig LoadConfig(string path) => ResourceLoader.LoadObject<HealthConfig>(path);

        public void Execute()
        {
            if (_currentHealth < _maxHealth)
            {
                _nextRechargeTime += Time.deltaTime;
                if (_nextRechargeTime >= _config.SpawnPeriod)
                {
                    _healthSpawner.Spawn();
                    _nextRechargeTime = 0f;
                }
            }
        }

        public void FixedExecute()
        {

        }

        public void Dispose()
        {
        }
    }
}
