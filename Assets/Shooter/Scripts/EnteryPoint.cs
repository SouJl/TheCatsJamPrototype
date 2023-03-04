using Shooter.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter 
{
    internal class EnteryPoint : MonoBehaviour
    {
        private readonly string playerCfgPath = @"Configs/Player/PlayerConfig";

        [SerializeField] private PlayerView _playerView;
        [SerializeField] private Components.ColorGun.ColorGunComponent _gun;

        private List<IExecute> _executeObjects = new List<IExecute>();

        private void Awake()
        {
            var playerController = CreatePlayerController(_playerView);
            _executeObjects.Add(playerController);
            _executeObjects.Add(_gun);
        }

        private void Update()
        {
            foreach (IExecute _executeObject in _executeObjects)
                _executeObject.Execute();
        }

        private void FixedUpdate()
        {
            foreach (IExecute _executeObject in _executeObjects)
                _executeObject.FixedExecute();
        }

        private IExecute CreatePlayerController(IPlayerView view)
        {
            IPlayerConfig config = LoadPlayerConfig(playerCfgPath);
            var controller = new PlayerController(view, config);

            return controller;
        }

        private IPlayerConfig LoadPlayerConfig(string path)
        {
            return Resources.Load<PlayerConfig>("Configs/Player/PlayerConfig");
        }
    }
}

