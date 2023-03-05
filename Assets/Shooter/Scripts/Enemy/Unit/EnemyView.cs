using Shooter.Components.ColorGun;
using System;
using System.Collections;
using UnityEngine;

namespace Shooter.Enemy
{
    internal class EnemyView : MonoBehaviour
    {
        public event Action<Vector3> onExploded;

        public void Explode()
        {
            gameObject.SetActive(false);
            onExploded?.Invoke(transform.position);
        }

        public void Damage()
        {
            gameObject.SetActive(false);
        }
    }
}
