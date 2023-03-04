using System;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class ColorBulletComponent : Bullet
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var IExplosiveComponent = collision.GetComponent<IExplosive>();
            if (IExplosiveComponent is { IsExploding: false })
                IExplosiveComponent.SetExplosive();
        }
    }
}
