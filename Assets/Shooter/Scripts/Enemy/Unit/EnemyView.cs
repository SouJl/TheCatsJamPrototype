using System;
using UnityEngine;

namespace Shooter.Enemy
{
    internal interface IEnemyView
    {
        Transform Transform { get; }
        Rigidbody2D Rigidbody { get; }

    }

    internal class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public Transform Transform => transform;

        public Rigidbody2D Rigidbody => _rigidbody;

        public event Action<Vector3> onExploded;

        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Explode()
        {
            gameObject.SetActive(false);
            onExploded?.Invoke(transform.position);
        }

        public void Damage()
        {
            gameObject.SetActive(false);
        }

        public void ChangeRigidPosition(Vector2 direction) =>
            _rigidbody.MovePosition((Vector2)transform.position + direction);
    }
}
