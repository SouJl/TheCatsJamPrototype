using System;
using System.Collections.Generic;

namespace Shooter.Components.ColorGun
{
    public class BulletPool
    {
        readonly List<IBullet> _bullets;

        public BulletPool()
        {
            _bullets = new List<IBullet>();
        }

        public void AddBullet(IBullet bullet)
        {
            _bullets.Add(bullet);
        }

        public IBullet GetBullet()
        {
            return _bullets.Find(bullet => !bullet.gameObject.activeSelf);
        }
    }
}
