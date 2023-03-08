using Shooter.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Components
{
    [RequireComponent(typeof(CircleCollider2D))]
    internal class NeighborCheckComponent : MonoBehaviour
    {
        [SerializeField] private float _colliderDistance = 4f;
        [SerializeField] private float _neighborCheckDist = 10f;
        [SerializeField] private CircleCollider2D _collider;

        private List<IEnemyView> _neighbors;

        private void OnValidate()
        {
            _collider ??= GetComponent<CircleCollider2D>();
            _collider.radius = _neighborCheckDist / 2f;
        }

        private void Start()
        {
            _neighbors = new List<IEnemyView>(); 
        }

        private void FixedUpdate()
        {
            if (_collider.radius != _neighborCheckDist / 2f)
                _collider.radius = _neighborCheckDist / 2f;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.gameObject.name);

            var neighbor = collision.GetComponent<IEnemyView>();
            if (neighbor != null)
            {
                if (_neighbors.IndexOf(neighbor) == -1)
                    _neighbors.Add(neighbor);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            var neighbor = collision.GetComponent<IEnemyView>();
            if (neighbor != null)
            {
                if (_neighbors.IndexOf(neighbor) != -1)
                    _neighbors.Remove(neighbor);
            }
        }

        public Vector2 AveragePosition
        {
            get
            {
                Vector2 avg = Vector2.zero;
                if (_neighbors.Count == 0) return avg;

                foreach (var neighbor in _neighbors)
                {
                    avg += (Vector2)neighbor.Transform.position;
                }

                return avg / _neighbors.Count;
            }
        }

        public Vector2 AvetageVelocity
        {
            get
            {
                Vector2 avg = Vector2.zero;
                if (_neighbors.Count == 0) return avg;

                foreach (var neighbor in _neighbors)
                {
                    avg += neighbor.Rigidbody.velocity;
                }

                return avg / _neighbors.Count;
            }
        }

        public Vector2 AverageClosePosition
        {
            get
            {
                Vector2 avg = Vector2.zero;
                Vector2 difference;
                int nearCount = 0;

                foreach (var neighbor in _neighbors)
                {
                    difference = neighbor.Transform.position - transform.position;
                    if (difference.magnitude <= _colliderDistance)
                    {
                        avg += (Vector2)neighbor.Transform.position;
                        nearCount++;
                    }
                }
                if (nearCount == 0) return avg;
                return avg / nearCount;
            }
        }

    }
}
