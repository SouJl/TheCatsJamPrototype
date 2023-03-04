using UnityEngine;

namespace Shooter.Components.ColorGun
{
    internal class BulletComponent : MonoBehaviour, IColorable
    {
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color coloredColor;
        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] Rigidbody2D rigidbody;
        [SerializeField] Collider2D triggerCollider;

        public bool IsColored { get; set; }

        public void Launch(bool isBulletColored, Vector3 velocity)
        {
            if (isBulletColored)
            {
                SetColored();
            }
            else 
            {
                SetDefaultColored();
            }

            rigidbody.velocity = velocity;
        }

        public void SetColored()
        {
            IsColored = true;
            spriteRenderer.color = coloredColor;
        }

        public void SetDefaultColored()
        {
            IsColored = false;
            spriteRenderer.color = defaultColor;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var IColorableComponent = collision.GetComponent<IColorable>();
            var IExplosiveComponent = collision.GetComponent<IExplosive>();

            if (IColorableComponent is IColorable)
            {
                if (IsColored == true)
                {
                    if (IColorableComponent.IsColored == false)
                    {
                        IColorableComponent.SetColored();
                    }
                }
                else if (IsColored == false)
                {
                    if (IColorableComponent.IsColored == true && IExplosiveComponent is IExplosive)
                    {
                        IExplosiveComponent.Explode();
                    }
                }
            }

            Destroy(gameObject);
        }
    }
}

