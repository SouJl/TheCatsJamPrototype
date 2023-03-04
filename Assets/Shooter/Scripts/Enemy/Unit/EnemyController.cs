using Shooter.Tool;
using System;
using UnityEngine;

namespace Shooter.Enemy
{
    internal class EnemyController : IExecute
    {
        private readonly string _configPath = @"Configs/Enemy/EnemyConfig";

        private readonly Transform _playerPos;
        private readonly IEnemyView _view;
        private readonly IEnemyConfig _config;

        private Action<GameObject> _onDestroy;

        public GameObject GameObject { get; private set; }

        public EnemyController(
            Transform playerPos, 
            IEnemyView view, 
            GameObject gameObject, 
            Action<GameObject> OnDestroy)
        {
            _playerPos 
                = playerPos ?? throw new ArgumentNullException(nameof(playerPos));

            _view 
                = view ?? throw new ArgumentNullException(nameof(view));

            _onDestroy = OnDestroy;

            GameObject = gameObject;

            _config = LoadConfig(_configPath);

            _view.Init(OnCollisionEnter);
        }

        private IEnemyConfig LoadConfig(string configPath) => 
            ResourceLoader.LoadObject<EnemyConfig>(configPath);

        private void OnCollisionEnter()
        {
            _view.Deinit();
            _onDestroy?.Invoke(GameObject); 
        }

        public void Execute()
        {
            RotateTowardsTargetPosition(_playerPos.position);

            Debug.Log(_playerPos.position);

            Vector3 diff = _playerPos.position - _view.Transform.position;
            diff.Normalize();

            _view.Transform.position += diff * (_config.Speed * Time.deltaTime);
        }

        private void RotateTowardsTargetPosition(Vector3 targetPos)
        {
            Vector3 diff = targetPos - _view.Transform.position;
            diff.Normalize();
            float rotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            _view.Transform.rotation = Quaternion.Euler(0f, 0f, rotation - 90);
        }

        public void FixedExecute()
        {
                
        }

        public void Dispose()
        {
            _view.Deinit();
            _onDestroy = default;
        }
    }
}
