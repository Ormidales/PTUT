using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string description;
    public Sprite image;
    public int price;

    public abstract void action();
}
