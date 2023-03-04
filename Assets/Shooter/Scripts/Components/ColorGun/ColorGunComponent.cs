using UnityEngine;

namespace Shooter.Components.ColorGun
{
    internal class ColorGunComponent : MonoBehaviour, IExecute
    {
        [SerializeField] private float bulletSpeed;
        [SerializeField] GameObject bulletPrefab;

        private void Shoot(bool isBulletColored) 
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);
            BulletComponent bulletComponent = bulletInstance.GetComponent<BulletComponent>();

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 toMouseDirection = (mousePos - transform.position).normalized;
            Vector3 bulletVelocity = toMouseDirection * bulletSpeed;

            bulletComponent.Launch(isBulletColored, bulletVelocity);
        }

        public void Execute()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(true);
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                Shoot(false);
            }
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

