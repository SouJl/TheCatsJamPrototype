using UnityEngine;

namespace Shooter.Enemy
{
    internal interface IEnemyConfig
    {
        float Speed { get; }
        float RotationSpeed { get; }
        float Velocity { get; }
        float ColliderAvoid { get; }
        float VelocityMatching { get; }
        float FlockCentering { get; }
        float TargetPull { get; }
        float TargetPusch { get; }
        float TargetPushDistance { get; }
    }

    [CreateAssetMenu(fileName = nameof(EnemyConfig),
        menuName = "Configs/Enemy/" + nameof(EnemyConfig))]
    internal class EnemyConfig : ScriptableObject, IEnemyConfig
    {
        [field: SerializeField] public float Speed { get; private set; } = 5f;

        [field: SerializeField] public float RotationSpeed { get; private set; } = 0.0025f;

        [field: Header("Flock Settings")]

        [field: SerializeField] public float Velocity { get; private set; } = 30f;

        [field: SerializeField] public float ColliderAvoid { get; private set; } = 2f;
        [field: SerializeField] public float VelocityMatching { get; private set; } = 0.25f;
        [field: SerializeField] public float FlockCentering { get; private set; } = 0.2f;

        [field: SerializeField] public float TargetPull { get; private set; } = 2f;

        [field: SerializeField] public float TargetPusch { get; private set; } = 2f;
        [field: SerializeField] public float TargetPushDistance { get; private set; } = 5f;
    }
}
