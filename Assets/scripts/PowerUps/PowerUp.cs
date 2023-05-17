using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect powerUpEffect;

    void OnTriggerEnter2D(Collider2D other)
    {

        Destroy(gameObject);
        powerUpEffect.Apply(other.gameObject);
    }

}