using Shooter.Enemy;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class ExplosiveColorableMonoBehavior : MonoBehaviour, IExplosive, IColorable
    {
        public bool IsExploding { get; set; }
        public bool IsColored { get; set; }

        [SerializeField] private Collider2D collisionDetectionCollider;
        [SerializeField] private float explosionRadius;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color coloredColor;
        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private EnemyView _enemyView;

        private void Awake()
        {
            IsExploding = false;
            IsColored = false;
            spriteRenderer.color = defaultColor;
        }

        public virtual void Explode()
        {
            if (!IsColored) return;

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

            SetDefaultColored();
            _enemyView.CallDestroy();
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

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}