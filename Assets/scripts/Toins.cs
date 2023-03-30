using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toins : MonoBehaviour
{
    public Text MyScoreText;
    private int ScoreNum;

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
        ScoreNum = 50;
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
    public int getToins()
    {
        return ScoreNum;
    }
    public void setToins(int toins)
    {
        ScoreNum=toins;
        MyScoreText.text = ScoreNum.ToString();
    }
}
