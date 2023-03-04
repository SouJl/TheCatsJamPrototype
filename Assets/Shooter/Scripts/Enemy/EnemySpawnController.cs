using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Enemy
{
    internal class EnemySpawnController : IExecute
    {
        private readonly IEnemySpawnView _view;
        private readonly IEnemySpawnConfig _config;
        private readonly IEnemyPool _enemyPool;

        private List<IEnemyView> _enemyViews;

        public EnemySpawnController(
            IEnemySpawnView view, 
            IEnemySpawnConfig config, 
            IEnemyPool enemyPool)
        {
            _view
                = view ?? throw new ArgumentNullException(nameof(view));
            _config 
                = config ?? throw new ArgumentNullException(nameof(config));
            _enemyPool 
                = enemyPool ?? throw new ArgumentNullException(nameof(enemyPool));

            _view.Init(Spawner());

        }


        private IEnumerator Spawner()
        {
            var waitTimer = new WaitForSeconds(_config.SwpawnRate);

            while (true)
            {
                yield return waitTimer;
                var enemyView = _enemyPool.SpawnEnemy().GetComponent<EnemyView>();

            }
        }


        #region IExecute

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void FixedExecute()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            _view.Deinit();
        }

        #endregion
    }
}
