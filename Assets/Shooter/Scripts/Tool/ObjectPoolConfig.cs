using UnityEngine;

namespace Shooter.Tool
{
    internal  interface IObjectPoolConfig
    {
        int PoolSize { get; }
    }
    
    [CreateAssetMenu(fileName = nameof(ObjectPoolConfig), 
        menuName = "Configs/Tool/" + nameof(ObjectPoolConfig))]
    internal class ObjectPoolConfig : ScriptableObject, IObjectPoolConfig
    {
        [field: SerializeField] public int PoolSize { get; private set; }
    }
}
