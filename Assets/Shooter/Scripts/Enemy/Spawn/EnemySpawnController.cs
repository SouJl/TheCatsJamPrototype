using Shooter.Tool;
using System.Collections;
using System.Collections.Generic;
using Shooter.Controllers;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Shooter.Enemy
{
    internal class EnemySpawnController : IExecute
    {
        private readonly string _configPath = @"Configs/Enemy/EnemySpawnConfig";
        private readonly string _viewPath = @"Prefabs/Enemy/EnemySpawn";

        readonly HardcoreController _hardcoreController;
        private readonly Transform _playerTransform;
        private readonly IEnemySpawnConfig _config;
        private readonly EnemyObjectPool _enemyPool;
        private readonly IEnemySpawnView _view;

        private readonly List<EnemyController> _enemyControllers = new();

        public EnemySpawnController(HardcoreController hardcoreController, Transform playerTransform)
        {
            _hardcoreController = hardcoreController;
            _playerTransform = playerTransform;
            _config = LoadConfig(_configPath);
            _enemyPool = CreateEnemyPool(_config);
            _view = LoadView(_viewPath);

            _view.Init(Spawner());
        }

        private IEnemySpawnConfig LoadConfig(string path) =>
            Resources.Load<EnemySpawnConfig>(path);


        private EnemyObjectPool CreateEnemyPool(IEnemySpawnConfig config)
        {
            var enemyPool = new EnemyObjectPool(config.PoolConfig);
            EnemyView[] enemyViews = enemyPool.enemyViews;
            foreach (EnemyView enemyView in enemyViews)
                _enemyControllers.Add(new EnemyController(_playerTransform, enemyView));

            return enemyPool;
        }

        private EnemySpawnView LoadView(string path)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(path));
            return objectView.GetComponent<EnemySpawnView>();
        }

        private IEnumerator Spawner()
        {
            if (!_hardcoreController.IsStarted())
                yield return new WaitUntil(_hardcoreController.IsStarted);

            while (true)
            {
                yield return new WaitForSeconds(_hardcoreController.GetSpawnRate());
                var enemySpawnPos = _config.SpawnPositions[GetSpawnerIndex()];
                SpawnEnemy(enemySpawnPos);
            }
        }

        private void SpawnEnemy(Vector3 enemySpawnPos)
        {
            var enemyView = _enemyPool.SpawnEnemy();
            if (enemyView == null)
            {
                enemyView = _enemyPool.CreateEnemy();
                _enemyControllers.Add(new EnemyController(_playerTransform, enemyView));
            }

            enemyView.gameObject.SetActive(true);
            enemyView.transform.position = new Vector3(enemySpawnPos.x, enemySpawnPos.y, 0);
        }

        private int GetSpawnerIndex() => Random.Range(0, _config.SpawnerCount);

        public void Execute()
        {
            foreach (var enemyController in _enemyControllers)
                enemyController.Execute();
        }

        public void FixedExecute() { }

        public void Dispose()
        {
            _enemyControllers.Clear();
        }
    }
}
