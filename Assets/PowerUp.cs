using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerupEffect powerupEffect;

    void OnTriggerEnter2D(Collider2D other)
    {

        Destroy(gameObject);
        powerupEffect.Apply(other.gameObject);
    }

}
