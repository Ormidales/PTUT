using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private static int numberItems=5;
    public Item[] items = new Item[numberItems];
    public Image[] uiImage = new Image[numberItems];
    public Button[] buttons = new Button[numberItems];
    public Sprite noneItem;

    public static Inventory instance;

    private void Awake()
    {
        if (instance!=null)
        {
            UnityEngine.Debug.LogWarning("Only one instance of Inventory is expected !");
            return;
        }
        instance = this;
    }

    public bool AddItem(Item item)
    {
        int premiereValeurNulle = 0;

        for (int i = 0; i < numberItems; i++)
        {
            if (items[i] == null)
            {
                premiereValeurNulle = i;
                break; 
            }
        }

        if (items[premiereValeurNulle] == null)
        {
            items[premiereValeurNulle] = item;
            UpdateUiImage(premiereValeurNulle);
            return true;
        }
        return false;
        
    }

    public void UseItem(int index)
    {
        if (index >= 0 && index < items.Length && items[index])
        {
            items[index].action();
            items[index] = null;
            UpdateUiImage(index);
        }
    }
    
    public int getMaxItems()
    {
        return numberItems;
    }

    public void UpdateUiImage(int index){
        if(items[index]!=null)
        {
            uiImage[index].sprite = items[index].image;
            buttons[index].interactable = true;
        }
        else
        {
            uiImage[index].sprite = noneItem;
            buttons[index].interactable = false;
        }
    }

    public void UpdateAllUiImage(){
        for(int i=0;i<numberItems;i++)
        {
            UpdateUiImage(i);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        items=DataManager.items;
        UpdateAllUiImage();
    }

}