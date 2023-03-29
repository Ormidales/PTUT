using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public int damageOnCollision;

    private Collider2D triggerCollider;

    protected override void Start()
    {
        base.Start();
        triggerCollider = GetComponent<Collider2D>();
        triggerCollider.isTrigger = true; // activer le trigger
    }

    

    public override void Die()
    {
        Debug.Log("Mort de l'enemie");
        Destroy(gameObject);   
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

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            Player player = collider.GetComponent<Player>();
            player.Damage(damageOnCollision,null);
            StartCoroutine(Backoff());
        }
    }
}
