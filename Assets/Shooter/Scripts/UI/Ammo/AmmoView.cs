using UnityEngine;
using UnityEngine.UI;

namespace Shooter.UI
{
    internal class AmmoView : MonoBehaviour
    {
        [SerializeField] private Image _filler;
        [SerializeField] AudioSource _audioSource;

        private float _currentAmmo;
        AmmoController _ammoController;

        public void Init(float initialAmmo)
        {
            _currentAmmo = initialAmmo;
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
            _filler.fillAmount = _currentAmmo;
        }
    }
}
