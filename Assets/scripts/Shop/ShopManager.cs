using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private static int numberItems=5;
    public ItemInv[] items = new ItemInv[numberItems];
    public GameObject[] objectsUi = new GameObject[numberItems];
    public Image[] imagesUi = new Image[numberItems];
    public TextMeshProUGUI[] pricesUi = new TextMeshProUGUI[numberItems];
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<numberItems;i++)
        {
            pricesUi[i].text=items[i].price.ToString();
            imagesUi[i].sprite=items[i].image;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            ShopEnter.instance.closeShop();
        }
    }
    public void sellItem(int i)
    {
        if(Toins.instance.getToins()>=items[i].price)
        {
            if(Inventory.instance.AddItem(items[i]))
            {
                Toins.instance.setToins(Toins.instance.getToins()-items[i].price);
                objectsUi[i].SetActive(false);
            } 
        }
    }
}
