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

        private List<IExecute> _executeObjects = new List<IExecute>();

        private void Awake()
        {
            var pauseController = new PauseController();
            var healthBarController = new HealthController(_placeForUI);
            var bonusMultiplyController = new BonusMultiplyController();
            var scoreControleller = new ScoreController(_placeForUI, bonusMultiplyController);
            var ammoController = new AmmoController(_placeForUI);
            var playerController = new PlayerController(ammoController, healthBarController, scoreControleller);
            var endGameController = new EndGameController(pauseController, healthBarController, _placeForUI);

            _executeObjects.Add(playerController);
            _executeObjects.Add(ammoController);
            _executeObjects.Add(new EnemySpawnController(playerController.playerTransform));
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
