using UnityEngine;

namespace Shooter.Enemy
{
    internal interface IEnemyConfig
    {
        float Speed { get; }
    }

    [CreateAssetMenu(fileName = nameof(EnemyConfig),
        menuName = "Configs/Enemy/" + nameof(EnemyConfig))]
    internal class EnemyConfig : ScriptableObject, IEnemyConfig
    {
        [field: SerializeField] public float Speed { get; private set; }
    }
}
