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
        GameObject SpawnEnemy();
        void DespawnEnemy(GameObject enemy);
    }

    internal class EnemyObjectPool : IEnemyPool
    {
        private readonly string _prefabPath = "Prefabs/Enemy/EnenemyPrefab";
        private readonly Stack<GameObject> _enemyPool = new Stack<GameObject>();
        private readonly GameObject _enemyPrefab;
        private readonly Transform _root;

        public EnemyObjectPool(int poolSize)
        {
            _enemyPrefab = ResourceLoader.LoadPrefab(_prefabPath);
            _root = new GameObject($"[{nameof(EnemyObjectPool)}]").transform;
            GenerateEnemies(poolSize);
        }

        private void GenerateEnemies(int amount) 
        {
            for (int i = 0; i < amount; i++)
            {
                var enemy = Object.Instantiate(_enemyPrefab);
                enemy.transform.SetParent(_root);
                enemy.SetActive(false);
                
                _enemyPool.Push(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (_enemyPool.Any())
            {
                var enemy = _enemyPool.Pop();
                enemy.SetActive(true);
                return enemy;
            }

            GameObject newEnemy = Object.Instantiate(_enemyPrefab);
            newEnemy.transform.SetParent(_root);
            _enemyPool.Push(newEnemy);

            return newEnemy;
        }

        public void DespawnEnemy(GameObject enemy)
        {
            enemy.SetActive(false);
            _enemyPool.Push(enemy);
        }
    }
}
