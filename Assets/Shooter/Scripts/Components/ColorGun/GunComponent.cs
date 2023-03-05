using Shooter.Controllers;
using Shooter.Player;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class GunComponent : MonoBehaviour
    {
        [SerializeField] AudioSource _audioSource;
        [SerializeField] float _bulletSpeed;
        [SerializeField] Bullet _colorBulletPrefab;

        BulletPool _coloredBulletPool;
        AmmoController _ammoController;
        Transform _playerTransform;
        PauseController _pauseController;

        public void Init(AmmoController ammoController, Transform playerTransform, PauseController pauseController)
        {
            _coloredBulletPool = new BulletPool();
            _ammoController = ammoController;
            _playerTransform = playerTransform;
            _pauseController = pauseController;
        }

        public void Update()
        {
            if (Input.GetButtonDown("Fire1") && _ammoController.CanShoot() && !_pauseController.isPaused)
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
            _audioSource.Play();
            Vector3 bulletVelocity = transform.up * _bulletSpeed;
            bullet.Launch(bulletVelocity, _playerTransform.position);
        }


        public void FixedExecute() { }

        public void Dispose() { }
    }
}
