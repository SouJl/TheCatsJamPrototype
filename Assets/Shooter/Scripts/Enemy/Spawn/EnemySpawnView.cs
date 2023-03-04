using System.Collections;
using UnityEngine;

namespace Shooter.Enemy
{
    internal interface IEnemySpawnView 
    {
        void Init(IEnumerator spawner);
        void Deinit();
    }

    internal class EnemySpawnView : MonoBehaviour, IEnemySpawnView
    {
        public void Init(IEnumerator spawner)
        {
            StartCoroutine(spawner);
        }

        public void Deinit()
        {
            StopAllCoroutines();
        }
    }
}
