using Shooter.Components.ColorGun;
using System;
using System.Collections;
using UnityEngine;

namespace Shooter.Enemy
{
    internal class EnemyView : MonoBehaviour
    {
        public void Explode()
        {
            gameObject.SetActive(false);
        }
    }
}
