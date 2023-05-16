using UnityEngine;
using UnityEngine.SceneManagement;

public class Endlevel : MonoBehaviour
{
    private string sceneName; 
    public bool leNiveauEstUnWagon;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            sceneName=LevelManager.instance.getNextLevel(leNiveauEstUnWagon);

            DataManager.vie=Player.instance.currentHealth;
            DataManager.items=Inventory.instance.items;

            SceneManager.LoadScene(sceneName);
        }
    }
}