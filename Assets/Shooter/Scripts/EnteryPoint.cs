using Shooter.Enemy;
using Shooter.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter 
{
    internal class EnteryPoint : MonoBehaviour
    {
        private readonly string playerCfgPath = @"Configs/Player/PlayerConfig";
        private readonly string enemySpawnCfgPath = @"Configs/Enemy/EnemySpawnConfig";

        [SerializeField] private PlayerView _playerView;

        private List<IExecute> _executeObjects = new List<IExecute>();

        private void Awake()
        {
            var playerController = CreatePlayerController(_playerView);
            _executeObjects.Add(playerController);

            var enemySpawnController = CreateEnemyController();
            _executeObjects.Add(enemySpawnController);
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
            var config = LoadPlayerConfig(playerCfgPath);
            var controller = new PlayerController(view, config);

            return controller;
        }

        private IExecute CreateEnemyController()
        {
            var config = LoadEnemySpawnConfig(enemySpawnCfgPath);
            var enemyPool = new EnemyObjectPool(20);
            var controller = new EnemySpawnController(_playerView.transform, config, enemyPool);

            return controller;
        }

        private IPlayerConfig LoadPlayerConfig(string path)
        {
            return Resources.Load<PlayerConfig>(path);
        }

        private IEnemySpawnConfig LoadEnemySpawnConfig(string path)
        {
            return Resources.Load<EnemySpawnConfig>(path);
        }
    }
}

