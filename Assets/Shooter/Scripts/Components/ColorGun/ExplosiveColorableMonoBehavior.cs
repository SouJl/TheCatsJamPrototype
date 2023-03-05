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
        [SerializeField] AudioSource _audioSource;

        private void Awake()
        {
            IsExploding = false;
            spriteRenderer.color = defaultColor;
        }

        public void Explode()
        {
            _audioSource.Play();
            SetUnexplosive();
            _enemyView.Explode();
        }

        public void Damage()
        {
            SetUnexplosive();
            _enemyView.Explode();
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
