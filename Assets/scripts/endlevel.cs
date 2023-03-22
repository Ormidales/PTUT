using UnityEngine;
using UnityEngine.SceneManagement;

public class endlevel : MonoBehaviour
{
    public int sceneId; 

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            SceneManager.LoadScene(sceneId);
        }
    }
}