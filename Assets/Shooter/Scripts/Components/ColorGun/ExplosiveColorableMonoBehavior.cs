using Shooter.Enemy;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class ExplosiveColorableMonoBehavior : MonoBehaviour, IExplosive
    {
        public bool IsExploding { get; private set; }

        [SerializeField] private float explosionRadius;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color coloredColor;
        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private EnemyView _enemyView;

        private void Awake()
        {
            IsExploding = false;
            spriteRenderer.color = defaultColor;
        }

        public void Explode()
        {
            SetUnexplosive();
            _enemyView.CallDestroy();
        }

        public void SetExplosive()
        {
            IsExploding = true;
            spriteRenderer.color = coloredColor;
        }

        private void SetUnexplosive()
        {
            IsExploding = false;
            spriteRenderer.color = defaultColor;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}
