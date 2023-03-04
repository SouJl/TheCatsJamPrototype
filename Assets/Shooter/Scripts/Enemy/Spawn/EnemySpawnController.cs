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

        private List<EnemyController> _enemyControllers = new List<EnemyController>();

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
                CreateEnemy(enemySpawnPos);
            }
        }

        private void CreateEnemy(Vector3 enemySpawnPos)
        {
            var enemyObjectView = _enemyPool.SpawnEnemy();
            enemyObjectView.transform.position = new Vector3(enemySpawnPos.x, enemySpawnPos.y, 0);
            var enemyView = enemyObjectView.GetComponent<EnemyView>();
            _enemyControllers.Add(new EnemyController(_playerPos, enemyView, enemyObjectView, OnEnemyDestroy));
        }

        private int GetSpawnerIndex() =>
            Random.Range(0, _config.SpawnerCount);

        private void OnEnemyDestroy(GameObject gameObject)
        {
            var enemyCtrl = _enemyControllers.Find(e => e.GameObject == gameObject);
            enemyCtrl.Dispose();
            _enemyControllers.Remove(enemyCtrl);

            _enemyPool.DespawnEnemy(gameObject);
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

            foreach (var enemyController in _enemyControllers)
                enemyController.Dispose();

            _enemyControllers.Clear();
        }

        #endregion
    }
}
