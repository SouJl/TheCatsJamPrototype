using System;

namespace Shooter.Player
{
    internal class PlayerController : IExecute
    {
        private readonly IPlayerView _view;
        private readonly IPlayerConfig _config;

        public PlayerController(IPlayerView view, IPlayerConfig config)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));
            _config 
                = config ?? throw new ArgumentNullException(nameof(config));

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
