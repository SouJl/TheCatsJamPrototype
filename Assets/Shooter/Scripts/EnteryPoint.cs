using Shooter.Enemy;
using Shooter.Player;
using System.Collections.Generic;
using Shooter.UI;
using UnityEngine;

namespace Shooter
{
    internal class EnteryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUI;

        private List<IExecute> _executeObjects = new List<IExecute>();

        private void Awake()
        {
            var healthBarController = new HealthController(_placeForUI);
            var ammoController = new AmmoController();
            var playerController = new PlayerController(ammoController, healthBarController);

            _executeObjects.Add(playerController);
            _executeObjects.Add(new EnemySpawnController(playerController.playerTransform));
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
