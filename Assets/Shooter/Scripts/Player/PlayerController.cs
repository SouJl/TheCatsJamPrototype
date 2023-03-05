using Shooter.Tool;
using System;

namespace Shooter.Player
{
    internal class PlayerController : IExecute
    {
        private readonly string _configPath= @"Configs/Player/PlayerConfig";

        private readonly IPlayerView _view;
        private readonly IPlayerConfig _config;

        public PlayerController(IPlayerView view)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));

            _config = LoadConfig(_configPath);

        }

        private IPlayerConfig LoadConfig(string path) => 
            ResourceLoader.LoadObject<PlayerConfig>(path);


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
