using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toins : MonoBehaviour
{
    public Text MyScoreText;
    private int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyScoreText.text = ScoreNum.ToString();
    }

    private void OnTriggerEnter2D(Collider2D Coin) //metodo para validar coliciones
    {
        if (Coin.tag =="Toins")
        {
            ScoreNum += 1;
            Destroy(Coin.gameObject); 
            MyScoreText.text = ScoreNum.ToString();
        }
    }
}
