using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Powerups/SpeedBuff")]
public class SpeedBuff : PowerUpEffect
{ 
      public float amount;
      CountDown ct;

      public override void Apply(GameObject target)
      {
        target.GetComponent<PlayerMovement>().moveSpeed += amount;
        AudioManager.Instance.PlaySFX("buff");

      }

 
}