using TMPro;
using UnityEngine;

namespace Shooter.UI
{
    internal interface IScoreView
    {
        void Init(int initScoreValue);

        void UpdateScoreValue(int amount);
    }

    internal class ScoreView : MonoBehaviour, IScoreView
    {
        [SerializeField] private TMP_Text _scoreValueText;

        public void Init(int initScoreValue)
        {
            UpdateScoreValue(initScoreValue);
        }

        public void UpdateScoreValue(int amount)
        {
            _scoreValueText.text = GetStringScoreValue(amount);
        }

        private string GetStringScoreValue(int amount) =>
            $"{amount}";
    }
}
