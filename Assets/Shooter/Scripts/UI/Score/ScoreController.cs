using Shooter.Tool;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Shooter.UI
{
    internal class ScoreController
    {
        private readonly string _viewPath = @"Prefabs/UI/Score/ScoreView";
        private readonly string _configPath = @"Configs/Score/ScoreConfig";

        private readonly IScoreView _view;
        private readonly IScoreConfig _config;

        private readonly IBonusMultyManager _multyManager;

        private int _scroeMultiply;
        private int _scoreAmount;

        public int GameScore => _scoreAmount;

        public ScoreController(
            Transform placeforUI, 
            IBonusMultyManager multyManager)
        {
            _scroeMultiply = 1;
            _scoreAmount = 0;

            _view = LoadView(placeforUI);
            _config = LoadConfig(_configPath);

            _multyManager 
                = multyManager ?? throw new ArgumentNullException(nameof(multyManager));

            _multyManager.OnMultiplyUpdate += UpdateScoreMultiply;

            _view.Init(_scoreAmount);
        }

        private IScoreView LoadView(Transform placeforUI)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeforUI, false);
            return objectView.GetComponent<ScoreView>();
        }

        private IScoreConfig LoadConfig(string path)
            => ResourceLoader.LoadObject<ScoreConfig>(path);

        public void IncreaseScoreValue()
        {
            _scoreAmount += _config.ScoreAmount * _scroeMultiply;
            _view.UpdateScoreValue(_scoreAmount);
            _multyManager.IsRecquestMultiply = true;
        }

        public void UpdateScoreMultiply(int value)
        {
            _scroeMultiply = value;
            _view.UpdateScoreMulty(_scroeMultiply);
        }
    }
}
