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
        [SerializeField] private bool _executeSpawn = false;
        [SerializeField] private float _spwanRate = 1.2f;
        [SerializeField] private Transform[] _spawnPlaces;

        public void Init(IEnumerator spawner)
        {
            StartCoroutine(spawner);
        }

        public void Deinit()
        {
            StopAllCoroutines();
        }

        private int GetSpawnerIndex() =>
            Random.Range(0, _spawnPlaces.Length);
    }
}
