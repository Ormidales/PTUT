using UnityEngine;

[CreateAssetMenu(fileName="HealthBuff",menuName="Inventory/HealthBuff")]
public class ItemHealthBuff : ItemInv
{
    public int amount = 20;
    
    public override void action(){
        Player.instance.HealPlayer(amount);
    }

}
