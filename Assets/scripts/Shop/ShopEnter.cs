using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnter : MonoBehaviour
{
    public GameObject shop;
    private bool isAtShop=false;

    public static ShopEnter instance;
    
    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("Only one instance of ShopEnter is expected !");
            return;
        }
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           isAtShop=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           isAtShop=false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isAtShop && Input.GetKeyDown(KeyCode.M))
        {
            openShop();
        }
    }
    public void openShop()
    {
        PlayerMovement.instance.enabled=false;
        shop.SetActive(true);
    }
    public void closeShop()
    {
        PlayerMovement.instance.enabled=true;
        shop.SetActive(false);
    }
}
