using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public int damageOnCollision;
    public int maxHealth = 50;
    public int currentHealth;

    protected override void Start()
    {
        base.Start();
    }


    IEnumerator Backoff()
    {
        // reculez l'ennemi pendant 0,5 seconde
        float backoffDuration = 0.5f;
        float elapsed = 0f;
        Vector3 startingPos = transform.position;
        while (elapsed < backoffDuration)
        {
            transform.position = Vector3.Lerp(startingPos, startingPos - transform.right, elapsed / backoffDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    public override void Die()
    {
        base.Die();
        Debug.Log("Mort de l'enemie");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Player player = collision.transform.GetComponent<Player>();
            player.Damage(damageOnCollision, this);
            StartCoroutine(Backoff());
        }
    }
}
