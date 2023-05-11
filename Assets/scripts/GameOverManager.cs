using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameOverManager instance;
    
    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("Only one instance of GameOverManager is expected !");
            return;
        }
        instance = this;
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitButton()
    {
        Application.Quit();
    }

}
