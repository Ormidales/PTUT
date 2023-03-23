using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Charge la première scène de jeu
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        // Quitte l'application
        Application.Quit();
    }
}
