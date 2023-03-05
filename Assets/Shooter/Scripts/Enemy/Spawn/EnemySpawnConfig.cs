using Shooter.Tool;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Enemy
{
    internal interface IEnemySpawnConfig 
    {
        float SwpawnRate { get; }
        int SpawnerCount { get; }

        IObjectPoolConfig PoolConfig { get; }

        IReadOnlyList<Vector3> SpawnPositions { get; } 
    }

    [CreateAssetMenu(fileName = nameof(EnemySpawnConfig), menuName = "Configs/Enemy/" + nameof(EnemySpawnConfig))]
    internal class EnemySpawnConfig : ScriptableObject, IEnemySpawnConfig
    {
        [field: SerializeField] public float SwpawnRate { get; private set; } = 1.2f;

        [SerializeField] private ObjectPoolConfig _poolConfig;

        [SerializeField] private Vector3[] _spawnPositions;

        [HideInInspector] public int SpawnerCount => _spawnPositions.Length;

        public IReadOnlyList<Vector3> SpawnPositions => _spawnPositions;

        public IObjectPoolConfig PoolConfig => _poolConfig;
    }
}
