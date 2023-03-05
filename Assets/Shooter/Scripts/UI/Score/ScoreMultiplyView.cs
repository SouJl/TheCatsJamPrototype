using TMPro;
using UnityEngine;

namespace Shooter.UI
{  
    internal class ScoreMultiplyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _multiplyValueText;

        private void Awake()
        {
            _multiplyValueText.text = "";
        }

        public void ChangeMultyply(int changeValue)
        {
            _multiplyValueText.text = $"{changeValue}";
        }
    }
}
