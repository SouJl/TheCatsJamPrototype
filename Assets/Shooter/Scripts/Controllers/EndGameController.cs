using Shooter.Tool;
using Shooter.UI;
using Shooter.UI.EndGame;
using UnityEngine;

namespace Shooter.Controllers
{
    internal class EndGameController
    {
        private readonly string _viewPath = @"Prefabs/UI/EndGame/EndGameView";

        private readonly PauseController _pauseController;
        private readonly ScoreController _scoreController;
        private readonly EndGameView _endGameView;

        public EndGameController(Transform placeforUI, PauseController pauseController, HealthController healthController, ScoreController scoreController)
        {
            _pauseController = pauseController;
            _scoreController = scoreController;
            _endGameView = LoadView(placeforUI);
            _endGameView.Init();

            healthController.onHealthChanged += OnHealthChanged;
        }

        void OnHealthChanged(int health)
        {
            if (health <= 0)
            {
                _pauseController.Pause();
                _endGameView.Show(_scoreController.GameScore);
            }
        }

        EndGameView LoadView(Transform placeforUI)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeforUI, false);
            return objectView.GetComponent<EndGameView>();
        }
    }
}
