using Shooter.Player;
using Shooter.Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Shooter.UI
{
    public class HealthController : IExecute
    {
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
            _view.Init(_config.HealthPoints);

            _healthSpawner = Object.Instantiate(ResourceLoader.LoadPrefab(_healthSpawnerPrefab), placeforUI, false).GetComponent<HealthSpawner>();
            _healthSpawner.Init();

            _maxHealth = _config.HealthPoints;
            GenerateHealth(_maxHealth);
            _nextRechargeTime = 0f;
        }

        private IHealthBarView LoadView(Transform placeforUI)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeforUI, false);
            return objectView.GetComponent<HealthBarView>();
        }

        public void GenerateHealth(int count) 
        {
            _view.GenerateHealth(count);
            _currentHealth = _maxHealth;
        }

        public void IncreaseHealth()
        {
            int resultHealth = _currentHealth + 1;
            _currentHealth = resultHealth > _maxHealth ? _maxHealth : resultHealth;

            _view.UpdateHealthBar(_currentHealth);
        }

        public void DecreaseHealth()
        {
            int resultHealth = _currentHealth - 1;
            _currentHealth = resultHealth < 0 ? 0 : resultHealth;

            _view.UpdateHealthBar(_currentHealth);
        }

        private IHealthConfig LoadConfig(string path) => ResourceLoader.LoadObject<HealthConfig>(path);

        public void Execute()
        {
            if (_currentHealth < _maxHealth)
            {
                if (Time.time > _nextRechargeTime)
                {
                    _nextRechargeTime += _config.SpawnPeriod;
                    
                    _healthSpawner.Spawn();
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
