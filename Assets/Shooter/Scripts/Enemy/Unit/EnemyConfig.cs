using UnityEngine;

namespace Shooter.Enemy
{
    internal interface IEnemyConfig
    {
        float Speed { get; }
        float RotationSpeed { get; }
    }

    [CreateAssetMenu(fileName = nameof(EnemyConfig),
        menuName = "Configs/Enemy/" + nameof(EnemyConfig))]
    internal class EnemyConfig : ScriptableObject, IEnemyConfig
    {
        [field: SerializeField] public float Speed { get; private set; } = 5f;

        [field: SerializeField] public float RotationSpeed { get; private set; } = 0.0025f;
    }
}
