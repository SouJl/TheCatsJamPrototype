using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class Bullet : MonoBehaviour, IBullet
    {
        Vector2 _minScreenBounds;
        Vector2 _maxScreenBounds;
        Vector3 _velocity;

        public void Init()
        {
            gameObject.SetActive(false);
            _minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            _maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        public void Launch(Vector3 velocity, Vector3 position)
        {
            gameObject.SetActive(true);
            transform.position = position;
            _velocity = velocity;
        }

        void Update()
        {
            transform.position += _velocity * Time.deltaTime;

            Vector3 position = transform.position;
            if (position.x > _maxScreenBounds.x || position.y > _maxScreenBounds.y || position.x < _minScreenBounds.x || position.y < _minScreenBounds.y)
                gameObject.SetActive(false);
        }
    }
}
