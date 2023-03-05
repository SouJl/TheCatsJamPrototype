using Shooter.Tool;
using System;
using UnityEngine;

namespace Shooter.Enemy
{
    internal class EnemyController : IExecute
    {
        private readonly string _configPath = @"Configs/Enemy/EnemyConfig";

        private readonly Transform _playerTransform;
        private readonly EnemyView _view;
        private readonly IEnemyConfig _config;

        public EnemyController(Transform playerTransform, EnemyView view)
        {
            _playerTransform = playerTransform;
            _view = view;
            _config = LoadConfig(_configPath);
        }

        private IEnemyConfig LoadConfig(string configPath) =>
            ResourceLoader.LoadObject<EnemyConfig>(configPath);

        public void Execute()
        {
            RotateTowardsTargetPosition(_playerTransform.position);
            MoveTowardsTarget(_playerTransform.position);
        }

        private void MoveTowardsTarget(Vector3 targetPos)
        {
            Vector3 targeDiff = GetDifference(targetPos);
            _view.transform.position += targeDiff * (_config.Speed * Time.deltaTime);
        }

        private void RotateTowardsTargetPosition(Vector3 targetPos)
        {
            Vector3 targeDiff = GetDifference(targetPos);
            float angle = MathF.Atan2(targeDiff.y, targeDiff.x) * Mathf.Rad2Deg;
            var toRotation = Quaternion.Euler(0f, 0f, angle - 90f);
            _view.transform.localRotation = Quaternion.Slerp(_view.transform.localRotation, toRotation, _config.RotationSpeed);
        }

        private Vector3 GetDifference(Vector3 targetPos)
        {
            Vector3 diff = targetPos - _view.transform.position;
            diff.Normalize();
            return diff;
        }

        public void FixedExecute()
        {
        }

        public void Dispose()
        {
        }
    }
}
