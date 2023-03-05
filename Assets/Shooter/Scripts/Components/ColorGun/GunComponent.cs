using Shooter.Player;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class GunComponent : MonoBehaviour, IExecute
    {
        [SerializeField] float bulletSpeed;
        [SerializeField] PlayerView _playerView;
        [SerializeField] Bullet _colorBulletPrefab;

        BulletPool _coloredBulletPool;

        void Awake()
        {
            _coloredBulletPool = new BulletPool();
        }

        public void Execute()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                var bullet = _coloredBulletPool.GetBullet();
                if (bullet == null)
                {
                    bullet = Instantiate(_colorBulletPrefab, transform.position, transform.rotation);
                    bullet.Init();
                    _coloredBulletPool.AddBullet(bullet);
                }

                Shoot(bullet);
            }
        }

        private void Shoot(IBullet bullet)
        {
            Vector3 bulletVelocity = transform.up * bulletSpeed;
            bullet.Launch(bulletVelocity, _playerView.transform.position);
        }


        public void FixedExecute()
        {

        }

        public void Dispose()
        {

        }
    }
}
