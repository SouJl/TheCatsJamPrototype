using TMPro;
using UnityEngine;

namespace Shooter.UI
{
    internal interface IScoreView
    {
        void Init(int initScoreValue);

        void UpdateScoreValue(int amount);

        void UpdateScoreMulty(int amount);
    }

    internal class ScoreView : MonoBehaviour, IScoreView
    {
        [SerializeField] private TMP_Text _scoreValueText;
        [SerializeField] private ScoreMultiplyView _scoreMultiplyView;
        public void Init(int initScoreValue)
        {
            UpdateScoreValue(initScoreValue);
            UpdateScoreMulty(1);
        }

        public void UpdateScoreMulty(int amount)
        {
            if (amount == 1)
            {
                _scoreMultiplyView.gameObject.SetActive(false);
                return;
            }
            else
            {
                _scoreMultiplyView.gameObject.SetActive(true);
                _scoreMultiplyView.ChangeMultyply(amount);
            }
          
        }

        public void UpdateScoreValue(int amount)
        {
            _scoreValueText.text = $"{amount}";
        }

    }
}
