using UnityEngine;

namespace Shooter.Player
{
    internal interface IHealthConfig
    {
        int HealthPoints { get; }
    }

    [CreateAssetMenu(fileName = nameof(HealthConfig), menuName = "Configs/Health/" + nameof(HealthConfig))]
    internal class HealthConfig : ScriptableObject, IHealthConfig
    {
        [field: SerializeField] public int HealthPoints { get; private set; } = 3;
    }
}
