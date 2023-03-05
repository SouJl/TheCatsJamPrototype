using Shooter.Enemy;
using Shooter.Player;
using System.Collections.Generic;
using Shooter.Controllers;
using Shooter.UI;
using UnityEngine;
using Shooter.Tool;

namespace Shooter
{
    internal class EnteryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUI;

        private readonly List<IExecute> _executeObjects = new List<IExecute>();

        private void Awake()
        {
            var hardcoreController = new HardcoreController();
            var pauseController = new PauseController();
            var healthBarController = new HealthController(_placeForUI);
            var bonusMultiplyController = new BonusMultiplyController();
            var scoreController = new ScoreController(_placeForUI, bonusMultiplyController);
            var ammoController = new AmmoController(hardcoreController, _placeForUI);
            var playerController = new PlayerController(ammoController, healthBarController, scoreController);
            var endGameController = new EndGameController(_placeForUI, pauseController, healthBarController, scoreController);

            _executeObjects.Add(playerController);
            _executeObjects.Add(ammoController);
            _executeObjects.Add(hardcoreController);
            _executeObjects.Add(new EnemySpawnController(hardcoreController, playerController.playerTransform));
            _executeObjects.Add(bonusMultiplyController);
        }

        private void Update()
        {
            foreach (IExecute _executeObject in _executeObjects)
                _executeObject.Execute();
        }

        private void FixedUpdate()
        {
            foreach (IExecute _executeObject in _executeObjects)
                _executeObject.FixedExecute();
        }
    }
}
