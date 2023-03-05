using UnityEngine;

namespace Shooter.Player
{
    internal interface IAmmoConfig
    {
        float AmmoPerRecharge { get; }
        float AmmoRechargePeriod { get; }
    }

    [CreateAssetMenu(fileName = nameof(AmmoConfig), menuName = "Configs/Ammo/" + nameof(AmmoConfig))]
    internal class AmmoConfig : ScriptableObject, IAmmoConfig
    {
        [field: SerializeField] public float AmmoPerRecharge { get; private set; } = 0.1f;
        [field: SerializeField] public float AmmoRechargePeriod { get; private set; } = 0.1f;
    }
}
