using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class KillBulletComponent : Bullet
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var IExplosiveComponent = collision.GetComponent<IExplosive>();
            if (IExplosiveComponent is { IsExploding: true })
                IExplosiveComponent.Explode();
        }
    }
}
