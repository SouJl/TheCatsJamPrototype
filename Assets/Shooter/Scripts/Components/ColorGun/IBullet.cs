using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public interface IBullet
    {
        GameObject gameObject { get; }
        void Init();
        void Launch(Vector3 velocity, Vector3 position);
    }
}
