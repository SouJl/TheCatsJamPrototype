using Shooter.Tool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Shooter.Enemy
{
    internal class EnemySpawnController : IExecute
    {
        private readonly string _viewPath = @"Prefabs/Enemy/EnemySpawn";

        private readonly Transform _playerPos;
        private readonly IEnemySpawnConfig _config;
        private readonly IEnemyPool _enemyPool;
        private readonly IEnemySpawnView _view;

        private List<GameObject> _enemies = new List<GameObject>();

        private List<IExecute> _enemyControllers = new List<IExecute>();

        public EnemySpawnController(
            Transform playerPos,
            IEnemySpawnConfig config,
            IEnemyPool enemyPool)
        {
            _playerPos = playerPos;

            _config
                = config ?? throw new ArgumentNullException(nameof(config));
            _enemyPool
                = enemyPool ?? throw new ArgumentNullException(nameof(enemyPool));

            _view = LoadView(_viewPath);

            _view.Init(Spawner());

        }

        private EnemySpawnView LoadView(string path)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(path));
            return objectView.GetComponent<EnemySpawnView>();
        }


        private IEnumerator Spawner()
        {
            var waitTimer = new WaitForSeconds(_config.SwpawnRate);

            while (true)
            {
                yield return waitTimer;

                var enemySpawnPos = _config.SpawnPositions[GetSpawnerIndex()];
                EnemyView enemyView = CreateEnemy(enemySpawnPos);

                _enemyControllers.Add(new EnemyController(_playerPos, enemyView));
            }
        }

        private EnemyView CreateEnemy(Vector3 enemySpawnPos)
        {
            var enemyObjectView = _enemyPool.SpawnEnemy();
            enemyObjectView.transform.position = new Vector3(enemySpawnPos.x, enemySpawnPos.y, 0);
            _enemies.Add(enemyObjectView);

            return enemyObjectView.GetComponent<EnemyView>(); 
        }

        private int GetSpawnerIndex() =>
            Random.Range(0, _config.SpawnerCount);

        private void OnEnemyDestroy(GameObject gameObject)
        {
            var enemy = _enemies.Find(e => e == gameObject);
            _enemies.Remove(enemy);
            enemy.GetComponent<EnemyView>().Deinit();
            _enemyPool.DespawnEnemy(enemy);
        }

        #region IExecute

        public void Execute()
        {
            foreach (var enemyController in _enemyControllers)
                enemyController.Execute();
        }

        public void FixedExecute()
        {

        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            _view.Deinit();
            foreach (var enemy in _enemies)
                enemy.GetComponent<EnemyView>().Deinit();

            foreach (var enemyController in _enemyControllers)
                enemyController.Dispose();

            _enemies.Clear();
        }

        #endregion
    }
}
