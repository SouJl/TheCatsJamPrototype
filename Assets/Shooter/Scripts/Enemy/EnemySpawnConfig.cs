using UnityEngine;

namespace Shooter.Enemy
{
    internal interface IEnemySpawnConfig 
    {
        float SwpawnRate { get; }
    }

    [CreateAssetMenu(fileName = nameof(EnemySpawnConfig), menuName = "Configs/Enemy/" + nameof(EnemySpawnConfig))]
    internal class EnemySpawnConfig : ScriptableObject, IEnemySpawnConfig
    {
        [field: SerializeField] public float SwpawnRate { get; private set; } = 1.2f;
    }
}
