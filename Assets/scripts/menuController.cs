using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public void StartGame()
    {
        // Charge la première scène de jeu
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // Quitte l'application
        Application.Quit();
    }
}
