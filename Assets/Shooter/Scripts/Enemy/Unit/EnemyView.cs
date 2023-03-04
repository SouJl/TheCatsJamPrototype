using System;
using System.Collections;
using UnityEngine;

namespace Shooter.Enemy
{
    internal interface IEnemyView
    {
        Transform Transform { get; }
        void Init();
        void Deinit();
    }

    internal class EnemyView : MonoBehaviour, IEnemyView
    {
        [field: SerializeField] public Transform Transform { get; private set; }

        private void Awake()
        {
            Transform = GetComponent<Transform>();
        }
        
        public void Init()
        {
           
        }

        public void Deinit()
        {
            
        }
    }
}
