using UnityEngine;

public abstract class ItemInv : ScriptableObject
{
    public string description;
    public Sprite image;
    public int price;

    public abstract void action();
}
