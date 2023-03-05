using Shooter.Tool;
using Shooter.UI;
using System;
using UnityEngine;

namespace Shooter.Player
{
    internal class PlayerController : IExecute
    {
        private readonly string _configPath= @"Configs/Player/PlayerConfig";

        private readonly IPlayerView _view;
        private readonly IPlayerConfig _config;
        private readonly IPlayer _playerModel;

        private HealthBarController _healthBarController;

        public PlayerController(Transform placeForUI, IPlayerView view)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));

            _config = LoadConfig(_configPath);

            _playerModel = new PlayerModel(_config);

            _healthBarController = CreateHealthBatController(placeForUI, _playerModel);
        }

        private IPlayerConfig LoadConfig(string path) => 
            ResourceLoader.LoadObject<PlayerConfig>(path);

        private HealthBarController CreateHealthBatController(Transform placeForUI, IPlayer playerModel)
        {
            var healthBarController = new HealthBarController(placeForUI, playerModel);
            return healthBarController;
        }

        #region IExecute

        public void Execute()
        {
            
        }

        public void FixedExecute()
        {
            
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            
        }

        #endregion
    }
}
