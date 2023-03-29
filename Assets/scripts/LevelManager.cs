using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    public int numberOfWagons=5;
    private int numberOfWagonsDone=0;

    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("Only one instance of LevelManager is expected !");
            return;
        }
        instance = this;
    }
    
    public string getNextLevel(bool inWagon)
    {
        if(numberOfWagonsDone<numberOfWagons)
        {
            if(inWagon)
            {
                //lancer la map gare
                return "station01";
            }
            else
            {
                numberOfWagonsDone++;
                string res = "level0"+Random.Range(1,3);
                return res;
            }
        }
        return "menu";
    }
}
