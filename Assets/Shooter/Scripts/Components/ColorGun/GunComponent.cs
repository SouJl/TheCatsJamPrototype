using Shooter.Player;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class GunComponent : MonoBehaviour, IExecute
    {
        [SerializeField] AmmoManager _ammoManager;
        [SerializeField] float _bulletSpeed;
        [SerializeField] PlayerView _playerView;
        [SerializeField] Bullet _colorBulletPrefab;

        BulletPool _coloredBulletPool;

        void Awake()
        {
            _coloredBulletPool = new BulletPool();
        }

        public void Execute()
        {
            if (Input.GetButtonDown("Fire1") && _ammoManager.CurrentAmmo > 0)
            {
                var bullet = _coloredBulletPool.GetBullet();
                if (bullet == null)
                {
                    bullet = Instantiate(_colorBulletPrefab, transform.position, transform.rotation);
                    bullet.Init();
                    _coloredBulletPool.AddBullet(bullet);
                }

                Shoot(bullet);

                _ammoManager.SubstractAmmo(_ammoManager.ammoPerShot);
            }
        }

        private void Shoot(IBullet bullet)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 toMouseDirection = (mousePos - transform.position).normalized;
            Vector3 bulletVelocity = toMouseDirection * _bulletSpeed;

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
