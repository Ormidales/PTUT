using UnityEngine;

[CreateAssetMenu(fileName="HealthBuff",menuName="Inventory/HealthBuff")]
public class ItemHealthBuff : Item
{
    public int amount = 20;
    
    public override void action(){
        Player.instance.HealPlayer(amount);
    }

}
