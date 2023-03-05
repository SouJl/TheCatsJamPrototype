using UnityEngine;

namespace Shooter.Controllers
{
    public class PauseController
    {
        float _currentTimeScale;

        public PauseController()
        {
            Play();
        }

        public void Pause()
        {
            _currentTimeScale = 0;
            SetTimeScale();
        }

        void Play()
        {
            _currentTimeScale = 1f;
            SetTimeScale();
        }

        void SetTimeScale()
        {
            Time.timeScale = _currentTimeScale;
        }
    }
}
