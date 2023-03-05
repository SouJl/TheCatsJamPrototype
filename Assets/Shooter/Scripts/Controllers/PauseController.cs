using UnityEngine;

namespace Shooter.Controllers
{
    public class PauseController
    {
        public bool isPaused => _isPaused;

        float _currentTimeScale;
        bool _isPaused;

        public PauseController()
        {
            Play();
        }

        public void Pause()
        {
            _currentTimeScale = 0;
            SetTimeScale();
            _isPaused = true;
        }

        void Play()
        {
            _currentTimeScale = 1f;
            SetTimeScale();
            _isPaused = false;
        }

        void SetTimeScale()
        {
            Time.timeScale = _currentTimeScale;
        }
    }
}
