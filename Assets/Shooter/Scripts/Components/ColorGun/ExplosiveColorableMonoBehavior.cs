using Shooter.Enemy;
using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class ExplosiveColorableMonoBehavior : MonoBehaviour, IExplosive
    {
        public bool IsExploding { get; private set; }

        [SerializeField] private float explosionRadius;
        [SerializeField] private Sprite uncoloredSprite;
        [SerializeField] private Sprite coloredSprite;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private EnemyView _enemyView;

        private void Awake()
        {
            IsExploding = false;
            spriteRenderer.sprite = uncoloredSprite;
        }

        public void Explode()
        {
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
            spriteRenderer.sprite = coloredSprite;
        }

        private void SetUnexplosive()
        {
            IsExploding = false;
            spriteRenderer.sprite = uncoloredSprite;
        }
    }
}
