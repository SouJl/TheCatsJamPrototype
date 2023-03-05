using Shooter.Tool;
using Shooter.UI;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Shooter.Player
{
    public class PlayerController : IExecute
    {
        public Transform playerTransform => _view.transform;

        private readonly string _configPath= @"Configs/Player/PlayerConfig";
        private readonly string _viewPath = @"Prefabs/Player/Player";

        private readonly PlayerView _view;
        private readonly IPlayerConfig _config;
        private readonly IPlayer _playerModel;

        public PlayerController(
            AmmoController ammoController, 
            HealthController healthController, 
            ScoreController scoreController)
        {
            _view = LoadView(_viewPath);
            _view.Init(ammoController, healthController, scoreController);

            _config = LoadConfig(_configPath);
            _playerModel = new PlayerModel(_config);
        }

        private IPlayerConfig LoadConfig(string path) => ResourceLoader.LoadObject<PlayerConfig>(path);

        private PlayerView LoadView(string path)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(path));
            return objectView.GetComponent<PlayerView>();
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
