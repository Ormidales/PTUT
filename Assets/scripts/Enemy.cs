using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageOnCollision;
    public int maxHealth = 50;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
       currentHealth -= damage;
        

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Mort de l'enemie");
        Destroy(gameObject);   
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.CompareTag("Player")){
            Player player = collision.transform.GetComponent<Player>();
            player.TakeDamage(damageOnCollision);
        }
    }
}
