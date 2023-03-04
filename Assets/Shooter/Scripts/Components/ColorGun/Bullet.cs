using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] Rigidbody2D rigidbody;
        Vector2 _minScreenBounds;
        Vector2 _maxScreenBounds;

        public void Init()
        {
            gameObject.SetActive(false);
            _minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            _maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        public void Launch(Vector3 velocity, Vector3 position)
        {
            gameObject.SetActive(true);
            rigidbody.velocity = velocity;
            transform.position = position;
        }

        void Update()
        {
            Vector3 position = transform.position;
            if (position.x > _maxScreenBounds.x || position.y > _maxScreenBounds.y || position.x < _minScreenBounds.x || position.y < _minScreenBounds.y)
                gameObject.SetActive(false);
        }
    }
}
