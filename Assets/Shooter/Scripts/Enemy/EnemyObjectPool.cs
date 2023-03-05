using Shooter.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Shooter.Enemy
{
    internal interface IEnemyPool
    {
        EnemyView SpawnEnemy();
    }

    internal class EnemyObjectPool : IEnemyPool
    {
        public EnemyView[] enemyViews => _enemyPool.ToArray();

        private readonly string _prefabPath = "Prefabs/Enemy/EnenemyPrefab";
        private readonly IObjectPoolConfig _config;
        private readonly List<EnemyView> _enemyPool = new();
        private readonly EnemyView _enemyPrefab;
        private readonly Transform _root;

        public EnemyObjectPool(IObjectPoolConfig config)
        {
            _config = config;
            _enemyPrefab = ResourceLoader.LoadObject<EnemyView>(_prefabPath);
            _root = new GameObject($"[{nameof(EnemyObjectPool)}]").transform;

            GenerateEnemies(_config.PoolSize);
        }

        private void GenerateEnemies(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                EnemyView enemy = Object.Instantiate(_enemyPrefab, _root, true);
                enemy.gameObject.SetActive(false);
                _enemyPool.Add(enemy);
            }
        }

        public EnemyView CreateEnemy()
        {
            EnemyView enemyView = Object.Instantiate(_enemyPrefab, _root, true);
            enemyView.gameObject.SetActive(false);
            _enemyPool.Add(enemyView);
            return enemyView;
        }

        public EnemyView SpawnEnemy()
        {
            return _enemyPool.Find(enemy => !enemy.gameObject.activeSelf);
        }
    }
}
