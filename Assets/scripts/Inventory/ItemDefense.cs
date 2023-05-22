using UnityEngine;

[CreateAssetMenu(fileName="DefenseBuff",menuName="Inventory/DefenseBuff")]
public class ItemDefense : Item
{
    public float time = 5;

    public override void action(){
        Player.instance.setInvincible(time);
    }

}
