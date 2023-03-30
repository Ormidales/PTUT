using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            ShopEnter.instance.closeShop();
        }
    }
    public void sellObject1(int price)
    {
        if(Toins.instance.getToins()>=price)
        {
            Toins.instance.setToins(Toins.instance.getToins()-price);
            object1.SetActive(false);
        }
    }
    public void sellObject2(int price)
    {
        if(Toins.instance.getToins()>=price)
        {
            Toins.instance.setToins(Toins.instance.getToins()-price);
            object2.SetActive(false);
        }
    }
}
