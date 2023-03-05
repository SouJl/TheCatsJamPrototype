using UnityEngine;

namespace Shooter.Components.ColorGun
{
    public class KillerZoneComponent : MonoBehaviour
    {
        [SerializeField] float killerZoneRadius;
        [SerializeField] CircleCollider2D killerZoneTrigger;

        private void Awake()
        {
            killerZoneTrigger.radius = killerZoneRadius;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            var IExplosiveComponent = collision.GetComponent<IExplosive>();
            if (IExplosiveComponent is { IsExploding: true })
                IExplosiveComponent.Explode();
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, killerZoneRadius);
        }
    }
}
