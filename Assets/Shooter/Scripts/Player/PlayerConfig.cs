using UnityEngine;

namespace Shooter.Player
{
    internal interface IPlayerConfig
    {
        float HealthPoints { get; }

        float Speed { get; }
    }


    [CreateAssetMenu(fileName = nameof(PlayerConfig),
        menuName = "Configs/Player/" + nameof(PlayerConfig))]
    internal class PlayerConfig : ScriptableObject, IPlayerConfig
    {
        [field: SerializeField] public float HealthPoints { get; private set; } = 150f;

        [field: SerializeField] public float Speed { get; private set; } = 10f;
    }
}
