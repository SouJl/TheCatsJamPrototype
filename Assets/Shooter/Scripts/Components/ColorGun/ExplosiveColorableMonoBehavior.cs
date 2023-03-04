using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class ExplosiveColorableMonoBehavior : MonoBehaviour, IExplosive, IColorable
    {
        public bool IsExploding { get; set; }
        public bool IsColored { get; set; }

        [SerializeField] private float explosionDelay;
        [SerializeField] private Collider2D collisionDetectionCollider;
        [SerializeField] private float explosionRadius;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color coloredColor;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Start()
        {
            IsExploding = false;
            IsColored = false;
            spriteRenderer.color = defaultColor;
        }

        public virtual void Explode()
        {
            StartCoroutine(ExplodeCoroutine());
        }

        public virtual void SetColored()
        {
            IsColored = true;
            spriteRenderer.color = coloredColor;
        }

        public virtual void SetDefaultColored()
        {
            IsColored = false;
            spriteRenderer.color = defaultColor;
        }

        public IEnumerator ExplodeCoroutine() 
        {
            IsExploding = true;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
            foreach (Collider2D collider in colliders)
            {
                var IExplosiveComponent = collider.GetComponent<IExplosive>();

                if (IExplosiveComponent is IExplosive && IExplosiveComponent.IsExploding == false)
                {
                    IExplosiveComponent.Explode();
                }
            }

            yield return new WaitForSeconds(explosionDelay);
            Destroy(gameObject);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}