using UnityEngine;

namespace Shooter.Components
{
    public class Puff : MonoBehaviour
    {
        public bool isActive => _animation.isPlaying;

        [SerializeField] Animation _animation;
        bool _isActive;

        public void StartPuff()
        {
            _animation.Play();
        }
    }
}
