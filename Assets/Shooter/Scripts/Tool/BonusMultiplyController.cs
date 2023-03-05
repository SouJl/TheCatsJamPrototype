using Shooter.UI;
using System;
using UnityEngine;

namespace Shooter.Tool
{
    internal interface IBonusMultyManager : IExecute
    {
        event Action<int> OnMultiplyUpdate;
        int CurrentBonusMultiply { get; }
        bool IsRecquestMultiply { get; set; }
    }

    internal class BonusMultiplyController : IBonusMultyManager
    {
        private readonly string _configPath = @"Configs/Score/ScoreConfig";
        private readonly IScoreConfig _config;

        private float _lastUpdateTime;

        public event Action<int> OnMultiplyUpdate;

        public int CurrentBonusMultiply { get; private set; }
        public bool IsRecquestMultiply { get; set; }

        private float _timerResetDelay = 0.5f;

        public BonusMultiplyController()
        {
            CurrentBonusMultiply = 1;
            _config = LoadConfig(_configPath);
        }

        private IScoreConfig LoadConfig(string path) =>
            ResourceLoader.LoadObject<ScoreConfig>(path);

        public void Execute()
        {
            if (_lastUpdateTime > _config.ScoreResetTime && !IsRecquestMultiply)
            {
                if(_lastUpdateTime > _config.ScoreResetTime + _timerResetDelay)
                {
                    CurrentBonusMultiply = 1;
                    IsRecquestMultiply = false;
                    _lastUpdateTime = 0;
                    OnMultiplyUpdate?.Invoke(CurrentBonusMultiply);
                }
            }
            else if(IsRecquestMultiply)
            {
                CurrentBonusMultiply++;
                IsRecquestMultiply = false;
                _lastUpdateTime = 0;
                OnMultiplyUpdate?.Invoke(CurrentBonusMultiply);
            }

            _lastUpdateTime += Time.deltaTime;
        }

        public void FixedExecute()
        {

        }

        public void Dispose()
        {

        }
    }
}
