using System;
using Shooter.Controllers;
using Shooter.Player;
using Shooter.Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Shooter.UI
{
    public class HealthController
    {
        public event Action<int> onHealthChanged;

        private readonly string _viewPath = @"Prefabs/UI/Health/HealthBarView";
        private readonly string _configPath = @"Configs/Health/HealthConfig";

        private readonly IHealthBarView _view;
        readonly IHealthConfig _config;

        public HealthController(Transform placeforUI)
        {
            _view = LoadView(placeforUI);
            _config = LoadConfig(_configPath);
            _view.Init(_config.HealthPoints);

            _view.onHealthChanged += (health) => onHealthChanged?.Invoke(health);
        }

        private IHealthBarView LoadView(Transform placeforUI)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeforUI, false);
            return objectView.GetComponent<HealthBarView>();
        }

        public void DecreaseHealth()
        {
            _view.DecreaseHealth();
        }

        private IHealthConfig LoadConfig(string path) => ResourceLoader.LoadObject<HealthConfig>(path);
    }
}
