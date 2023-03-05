using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Shooter.UI.EndGame
{
    public class EndGameView : MonoBehaviour
    {
        [SerializeField] GameObject _root;
        [SerializeField] Button _button;

        public void Init()
        {
            _root.SetActive(false);
            _button.onClick.AddListener(OnRestartButtonClick);
        }

        void OnRestartButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Show()
        {
            _root.SetActive(true);
        }
    }
}
