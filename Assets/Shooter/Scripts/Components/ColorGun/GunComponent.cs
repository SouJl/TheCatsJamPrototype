using Shooter.Player;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class GunComponent : MonoBehaviour, IExecute
    {
        [SerializeField] float bulletSpeed;
        [SerializeField] PlayerView _playerView;
        [SerializeField] Bullet _colorBulletPrefab;
        [SerializeField] Bullet _killBulletPrefab;

        BulletPool _coloredBulletPool;
        BulletPool _killBulletPool;

        void Awake()
        {
            _coloredBulletPool = new BulletPool();
            _killBulletPool = new BulletPool();
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
            else if (Input.GetButtonDown("Fire2"))
            {
                var bullet = _killBulletPool.GetBullet();
                if (bullet == null)
                {
                    bullet = Instantiate(_killBulletPrefab, transform.position, transform.rotation);
                    bullet.Init();
                    _killBulletPool.AddBullet(bullet);
                }

                Shoot(bullet);
            }
        }

        private void Shoot(IBullet bullet)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 toMouseDirection = (mousePos - transform.position).normalized;
            Vector3 bulletVelocity = toMouseDirection * bulletSpeed;

            bullet.Launch(bulletVelocity, _playerView.transform.position);
        }


        public void FixedExecute()
        {

        }

        public void Dispose()
        {

        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }
    }
}
