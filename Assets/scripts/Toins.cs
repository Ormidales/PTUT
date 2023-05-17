using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toins : MonoBehaviour
{
    public Text coinsText;
    private int toins;

    public static Toins instance;
    
    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("Only one instance of Toins is expected !");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        toins=0;
        if(PlayerPrefs.HasKey("toins"))
        {
            toins = PlayerPrefs.GetInt("toins");
        }
        
        coinsText.text = toins.ToString();
        
        
    }

    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.tag =="Toins")
        {
            toins += 1;
            Destroy(Coin.gameObject); 
            coinsText.text = toins.ToString();
            PlayerPrefs.SetInt("toins", toins);

            //AudioManager.Instance.PlaySFX("buff");
        }
    }

    public int getToins()
    {
        return toins;
    }
    public void setToins(int t)
    {
        toins=t;
        PlayerPrefs.SetInt("toins", toins);
        coinsText.text = toins.ToString();
    }
}
