using Shooter.Player;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class GunComponent : MonoBehaviour
    {
        [SerializeField] float _bulletSpeed;
        [SerializeField] Bullet _colorBulletPrefab;

        BulletPool _coloredBulletPool;
        AmmoController _ammoController;
        Transform _playerTransform;

        public void Init(AmmoController ammoController, Transform playerTransform)
        {
            _coloredBulletPool = new BulletPool();
            _ammoController = ammoController;
            _playerTransform = playerTransform;
        }

        public void Update()
        {
            if (Input.GetButtonDown("Fire1") && _ammoController.CurrentAmmo > 0)
            {
                var bullet = _coloredBulletPool.GetBullet();
                if (bullet == null)
                {
                    bullet = Instantiate(_colorBulletPrefab, transform.position, transform.rotation);
                    bullet.Init();
                    _coloredBulletPool.AddBullet(bullet);
                }

                Shoot(bullet);
                _ammoController.ResetAmmo();
            }
        }

        private void Shoot(IBullet bullet)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 toMouseDirection = (mousePos - transform.position).normalized;
            Vector3 bulletVelocity = toMouseDirection * _bulletSpeed;

            bullet.Launch(bulletVelocity, _playerTransform.position);
        }
    }
}
