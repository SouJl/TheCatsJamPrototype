using UnityEngine;

namespace Shooter.Player
{
    internal interface IHealthConfig
    {
        int HealthPoints { get; }
        float SpawnPeriod { get; }
    }

    [CreateAssetMenu(fileName = nameof(HealthConfig), menuName = "Configs/Health/" + nameof(HealthConfig))]
    internal class HealthConfig : ScriptableObject, IHealthConfig
    {
        [field: SerializeField] public int HealthPoints { get; private set; } = 3;
        [field: SerializeField] public float SpawnPeriod { get; private set; } = 1f;
    }
}
