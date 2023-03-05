using System;
using Shooter.Player;
using Shooter.Tool;
using UnityEngine;

namespace Shooter.Controllers
{
    public class HardcoreController : IExecute
    {
        private readonly string _configPath = @"Configs/Hardcore/HardcoreConfig";

        readonly IHardcoreConfig _config;
        HardcoreConfig.Hardcore _currentHardcore;
        bool _isStarted;
        float _currentTime;

        public HardcoreController()
        {
            _config = LoadConfig();
        }

        private IHardcoreConfig LoadConfig() => ResourceLoader.LoadObject<HardcoreConfig>(_configPath);

        public bool IsStarted()
        {
            return _isStarted;
        }

        public float GetSpawnRate()
        {
            return _currentHardcore.enemySpawnRate;
        }

        public float GetEnemyAmmoHealth()
        {
            return _currentHardcore.enemyAmmoHealthIncrease;
        }

        public void Execute()
        {
            _currentTime += Time.deltaTime;
            if (!_isStarted)
            {
                if (_currentTime > _config.StartDelay)
                {
                    _isStarted = true;
                    _currentHardcore = _config.hardcores[0];
                    _currentTime = 0f;
                }
            }
            else if (_currentTime > _currentHardcore.stepLength)
            {
                int index = _currentHardcore.index;
                int newIndex = index + 1;
                var currentHardcore = Array.Find(_config.hardcores, hardcore => hardcore.index == newIndex);
                if (currentHardcore != null)
                    _currentHardcore = currentHardcore;
                _currentTime = 0f;
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
