using UnityEngine;

[CreateAssetMenu(fileName="SpeedBuff",menuName="Inventory/SpeedBuff")]
public class ItemSpeed : Item
{
    public float time = 5;
    public int speed = 5;
    
    public override void action(){
        PlayerMovement.instance.speedBuffAction(speed,time);
    }

    

}
