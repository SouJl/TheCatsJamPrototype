using UnityEngine;

namespace Shooter.Enemy
{
    internal interface IEnemyView
    {
        void SetActive(bool state);
    }

    internal class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }
        
        public void SetActive(bool state) => 
            gameObject.SetActive(state);
    }
}
