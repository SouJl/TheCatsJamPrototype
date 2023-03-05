using Shooter.Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Shooter.UI
{
    public class ScoreController
    {
        private readonly string _viewPath = @"Prefabs/UI/Score/ScoreView";
        private readonly string _configPath = @"Configs/Score/ScoreConfig";

        private readonly IScoreView _view;
        private readonly IScoreConfig _config;
        private int _scoreMuliply;
        private int _scoreAmount;

        public int GameScore => _scoreAmount;

        public ScoreController(Transform placeforUI)
        {
            _scoreMuliply = 1;
            _scoreAmount = 0;

            _view = LoadView(placeforUI);
            _config = LoadConfig(_configPath);

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
            _scoreAmount += _config.ScoreAmount * _scoreMuliply;
            _view.UpdateScoreValue(_scoreAmount);
        }

        public void IncreaseScoreMuliply() 
        {
            _scoreMuliply++;
        }

        public void ReserScoreMuliply() => _scoreMuliply = 0;
    }
}
