using Shooter.Tool;
using Shooter.UI;
using Shooter.UI.EndGame;
using UnityEngine;

namespace Shooter.Controllers
{
    public class EndGameController
    {
        private readonly string _viewPath = @"Prefabs/UI/EndGame/EndGameView";

        readonly PauseController _pauseController;
        readonly EndGameView _endGameView;

        public EndGameController(PauseController pauseController, HealthController healthController, Transform placeforUI)
        {
            _pauseController = pauseController;
            _endGameView = LoadView(placeforUI);
            _endGameView.Init();

            healthController.onHealthChanged += OnHealthChanged;
        }

        void OnHealthChanged(int health)
        {
            if (health <= 0)
            {
                _pauseController.Pause();
                _endGameView.Show();
            }
        }

        EndGameView LoadView(Transform placeforUI)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeforUI, false);
            return objectView.GetComponent<EndGameView>();
        }
    }
}
