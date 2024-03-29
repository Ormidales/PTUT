using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPauseManager : MonoBehaviour
{
    public GameObject menuPauseUI;
    public static MenuPauseManager instance;
    // Stocker la valeur initiale de Time.timeScale
    private float initialTimeScale;
    
    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("Only one instance of menuPauseManager is expected !");
            return;
        }
        instance = this;
    }
    
    public void bouton_reprendrePartie()
    {
    	menuPauseArret();  
        Time.timeScale = 1f; 
    }

    public void menuPause()
    {
        menuPauseUI.SetActive(true);
        initialTimeScale = Time.timeScale;
    }
    public void menuPauseArret()
    {
        menuPauseUI.SetActive(false);
        Time.timeScale = initialTimeScale;
    }
    public void bouton_recommencerPartie()
    {
        Time.timeScale = initialTimeScale;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        menuPauseUI.SetActive(false);
        
    }
    public void bouton_menuPrincipal()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = initialTimeScale;
    }
    public void bouton_quitterJeu()
    {
        Application.Quit();
        Time.timeScale = initialTimeScale;
    }
}