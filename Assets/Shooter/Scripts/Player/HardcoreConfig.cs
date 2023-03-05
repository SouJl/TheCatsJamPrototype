using System;
using UnityEngine;

namespace Shooter.Player
{
    internal interface IHardcoreConfig
    {
        float StartDelay { get; }
        HardcoreConfig.Hardcore[] hardcores { get; }
    }

    [CreateAssetMenu(fileName = nameof(HardcoreConfig), menuName = "Configs/Hardcore/" + nameof(HardcoreConfig))]
    public class HardcoreConfig : ScriptableObject, IHardcoreConfig
    {
        [Serializable]
        public class Hardcore
        {
            public int index;
            public float stepLength;
            public float enemySpawnRate;
            public float enemyAmmoHealthIncrease;
        }

        [field: SerializeField] public float StartDelay { get; private set; } = 5f;
        [field: SerializeField] public Hardcore[] hardcores { get; private set; }
    }
}
