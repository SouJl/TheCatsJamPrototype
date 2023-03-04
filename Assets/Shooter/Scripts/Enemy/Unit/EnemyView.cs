using Shooter.Components.ColorGun;
using System;
using System.Collections;
using UnityEngine;

namespace Shooter.Enemy
{
    internal interface IEnemyView
    {
        Transform Transform { get; }
        void Init(Action onTriggerEnter);
        void Deinit();
    }

    internal class EnemyView : MonoBehaviour, IEnemyView
    {
        [field: SerializeField] public Transform Transform { get; private set; }

        private Action _onTriggerEnter;

        private void Awake()
        {
            Transform = GetComponent<Transform>();
        }
        
        public void Init(Action onTriggerEnter)
        {
            _onTriggerEnter = onTriggerEnter;
        }

        public void Deinit()
        {
            _onTriggerEnter = default;
        }


        public void CallDestroy()
        {
            _onTriggerEnter?.Invoke();
        }
    }
}
