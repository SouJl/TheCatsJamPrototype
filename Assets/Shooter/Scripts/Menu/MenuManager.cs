using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OpenGameplayScene()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
