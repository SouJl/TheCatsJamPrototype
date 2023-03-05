using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Shooter.UI.EndGame
{
    public class EndGameView : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private TMP_Text _finalScoreText;
        [SerializeField] private Button _button;

        public void Init()
        {
            _root.SetActive(false);
            _button.onClick.AddListener(OnRestartButtonClick);
            _finalScoreText.text = "";
        }

        void OnRestartButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Show(int scoreValue)
        {
            _root.SetActive(true);
            _finalScoreText.text = $"Final Score: {scoreValue}";
        }
    }
}
