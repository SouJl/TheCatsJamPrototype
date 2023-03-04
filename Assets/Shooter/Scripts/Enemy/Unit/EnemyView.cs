using System;
using System.Collections;
using UnityEngine;

namespace Shooter.Enemy
{
    internal interface IEnemyView
    {
        Transform Transform { get; }
        void Init(Action<GameObject> onDestroy);
        void Deinit();
    }

    internal class EnemyView : MonoBehaviour, IEnemyView
    {
        [field: SerializeField] public Transform Transform { get; private set; }

        private Action<GameObject> _onDestroy; 

        private void Awake()
        {
            Transform = GetComponent<Transform>();
        }
        
        public void Init(Action<GameObject> onDestroy)
        {
            _onDestroy = onDestroy;
            StartCoroutine(OnEnd());
        }

        public void Deinit()
        {
            _onDestroy = default;
        }

        private IEnumerator OnEnd()
        {
            yield return new WaitForSeconds(3);
            _onDestroy?.Invoke(this.gameObject);
        }
    }
}
