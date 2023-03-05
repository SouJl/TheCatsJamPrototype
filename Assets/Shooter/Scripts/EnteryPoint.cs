using Shooter.Enemy;
using Shooter.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    internal class EnteryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private Components.ColorGun.GunComponent _gun;

        private List<IExecute> _executeObjects = new List<IExecute>();

        private void Awake()
        {
            var playerController = CreatePlayerController(_playerView);
            _executeObjects.Add(playerController);

            var enemySpawnController = CreateEnemyController();
            _executeObjects.Add(enemySpawnController);
            _executeObjects.Add(_gun);
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

        private IExecute CreatePlayerController(IPlayerView view)
        {
            var controller = new PlayerController(view);
            return controller;
        }

        private IExecute CreateEnemyController()
        {
            var controller = new EnemySpawnController(_playerView.transform);
            return controller;
        }
    }
}
