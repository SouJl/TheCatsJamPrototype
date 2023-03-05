using UnityEngine;
using UnityEngine.UI;

namespace Shooter.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _healthItem;

        public void SetSprite(Sprite sprite)
        {
            _healthItem.sprite = sprite;
        }
    }
}
