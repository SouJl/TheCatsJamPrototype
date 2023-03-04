using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shooter.Enemy
{
    internal interface IEnemyPool
    {
        GameObject SpawnEnemy();
        void DespawnEnemy(GameObject enemy);
    }

    internal class EnemyObjectPool : IEnemyPool
    {
        private readonly string _prefabPath = "Prefabs/EnenemyPrefab";
        private readonly Stack<GameObject> _enemyPool = new Stack<GameObject>();
        private readonly GameObject _enemyPrefab;

        public EnemyObjectPool(int poolSize)
        {
            _enemyPrefab = LoadPrefab(_prefabPath);
            GenerateEnemies(poolSize);
        }

        private void GenerateEnemies(int amount) 
        {
            for (int i = 0; i < amount; i++)
            {
                var enemy = Object.Instantiate(_enemyPrefab);
                enemy.SetActive(false);
                _enemyPool.Push(enemy);
            }
        }

        private GameObject LoadPrefab(string prefabPath) => 
            Resources.Load<GameObject>(prefabPath);


        public GameObject SpawnEnemy()
        {
            if (_enemyPool.Any())
            {
                var enemy = _enemyPool.Pop();
                enemy.SetActive(true);
                return enemy;
            }

            GameObject newEnemy = Object.Instantiate(_enemyPrefab);
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
