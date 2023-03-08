using Shooter.Tool;
using System;
using Shooter.Scripts.Controllers;
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
            var puffController = new PuffController(view);
        }

        private IEnemyConfig LoadConfig(string configPath) =>
            ResourceLoader.LoadObject<EnemyConfig>(configPath);

        public void Execute()
        {
            RotateTowardsTargetPosition(_playerTransform.position);
        }

        public void FixedExecute()
        {   
            MoveTowardsTarget(_playerTransform.position);
        }

        private void RotateTowardsTargetPosition(Vector3 targetPos)
        {
            Vector3 targeDiff = GetDifference(targetPos);
            float angle = MathF.Atan2(targeDiff.y, targeDiff.x) * Mathf.Rad2Deg;
            var toRotation = Quaternion.Euler(0f, 0f, angle - 90f);
            _view.transform.localRotation = Quaternion.Slerp(_view.transform.localRotation, toRotation, _config.RotationSpeed);
        }

        private void MoveTowardsTarget(Vector3 targetPos)
        {
            //Vector2 targeDiff = GetDifference(targetPos);

            Vector2 velocity = _view.Rigidbody.velocity;

            Vector2 atractorPos = _view.NeighborCheck.RandomNeighborPosition;

            Vector2 vellAvoid = 
                GetVelocityAvoid(_view.NeighborCheck.AverageClosePosition);
            Vector2 velAligin =
                ApplyVelocityAligin(_view.NeighborCheck.AvetageVelocity);
            Vector2 vellCenter = 
                GetVelocityCenter(_view.NeighborCheck.AveragePosition);

            Vector2 atractorDiff = atractorPos - (Vector2)_view.Transform.position;

            bool attracted = atractorDiff.magnitude > _config.TargetPushDistance;
            
            Vector2 velTarget = atractorDiff.normalized * _config.Velocity;

            float fdt = Time.fixedDeltaTime;

            if(vellAvoid != Vector2.zero)
            {
                velocity = Vector2.Lerp(velocity, vellAvoid, _config.ColliderAvoid * fdt);
            }
            else
            {
                if(velAligin != Vector2.zero)
                {
                    velocity = Vector2.Lerp(velocity, velAligin, _config.VelocityMatching * fdt);
                }
                if(vellCenter != Vector2.zero)
                {
                    velocity = Vector2.Lerp(velocity, velAligin, _config.FlockCentering * fdt);
                }
                if(velTarget != Vector2.zero)
                {
                    if (attracted)
                    {
                        velocity = Vector2.Lerp(velocity, velTarget, _config.TargetPull * fdt);
                    }
                    else
                    {
                        velocity = Vector2.Lerp(velocity, -velTarget, _config.TargetPusch * fdt);
                    }                
                }
            }

            velocity = velocity.normalized * _config.Velocity;

            _view.ChangeVelocity(velocity);

           // _view.ChangeRigidPosition(targeDiff * (_config.Speed * Time.fixedDeltaTime));
        }

        private Vector3 GetDifference(Vector3 targetPos)
        {
            Vector3 diff = targetPos - _view.transform.position;
            diff.Normalize();
            return diff;
        }

        private Vector2 GetVelocityAvoid(Vector2 closePosition)
        {
            Vector2 result = Vector2.zero;

            if (closePosition != Vector2.zero) 
            {
                result = (Vector2)_view.Transform.position - closePosition;
                result.Normalize();
                result *= _config.Velocity;
            }

            return result;
        }
        private Vector2 ApplyVelocityAligin(Vector2 averageVelocity)
        {
            if(averageVelocity != Vector2.zero)
            {
                averageVelocity.Normalize();
                averageVelocity *= _config.Velocity;
            }
            return averageVelocity;
        }

        private Vector2 GetVelocityCenter(Vector2 averagePosition)
        {
            Vector2 velocityCenter = averagePosition;

            if (velocityCenter != Vector2.zero)
            {
                velocityCenter -= (Vector2)_view.Transform.position;
                velocityCenter.Normalize();
                velocityCenter *= _config.Velocity;
            }

            return velocityCenter;
        }

        public void Dispose()
        {
        }
    }
}
