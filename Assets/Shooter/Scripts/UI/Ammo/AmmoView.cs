using UnityEngine;
using UnityEngine.UI;

namespace Shooter.UI
{
    internal class AmmoView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _filler;
        [SerializeField] private Gradient _gradient;

        [SerializeField] AudioSource _audioSource;

        private float _currentAmmo;
        AmmoController _ammoController;

        private void Awake()
        {
            _filler.color = _gradient.Evaluate(0);
        }


        public void Init(float initialAmmo)
        {
            _currentAmmo = initialAmmo;
            UpdateBar();
        }

        public void SetAmmo(float percentage)
        {
            _audioSource.Play();
            _currentAmmo = percentage;
            UpdateBar();
        }

        public void ResetAmmo()
        {
            _currentAmmo = 0;
            UpdateBar();
        }

        private void UpdateBar()
        {
            _slider.value = _currentAmmo;
            _filler.color = _gradient.Evaluate(_slider.normalizedValue);
        }
    }
}
