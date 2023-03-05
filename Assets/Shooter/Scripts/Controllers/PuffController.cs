using System.Collections.Generic;
using Shooter.Components;
using Shooter.Enemy;
using Shooter.Tool;
using UnityEngine;

namespace Shooter.Scripts.Controllers
{
    internal class PuffController
    {
        readonly List<Puff> _puffs = new();

        private readonly string _viewPath = @"Prefabs/Enemy/Puff";

        public PuffController(EnemyView enemyView)
        {
            enemyView.onExploded += OnEnemyViewExploded;
        }

        void OnEnemyViewExploded(Vector3 position)
        {
            Puff puff = _puffs.Find(puff => !puff.isActive);
            if (puff == null)
            {
                puff = LoadView();
                _puffs.Add(puff);
            }

            puff.transform.position = position;
            puff.StartPuff();
        }

        Puff LoadView()
        {
            return Object.Instantiate(ResourceLoader.LoadObject<Puff>(_viewPath), null, false);
        }
    }
}
