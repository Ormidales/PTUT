
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toins : MonoBehaviour
{
    public Text coinsText;
    private int toins;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("toins"))
        {
            toins = PlayerPrefs.GetInt("toins");
        }else
        {
            toins = 0;
        }
      coinsText.text = toins.ToString();
    }

    private void OnTriggerEnter2D(Collider2D Coin) //metodo para validar coliciones
    {
        if (Coin.tag =="Toins")
        {
            toins += 1;
            Destroy(Coin.gameObject); 
            coinsText.text = toins.ToString();
            PlayerPrefs.SetInt("toins", toins);
                        
            AudioManager.Instance.PlaySFX("buff");
        }
    }
}
