using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;

    public float range = 1f;

    private float timeBetweenAttack = 0.75f;
    private float timer = 0;

    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && Time.time - timer > timeBetweenAttack)
        {
            Attack();
            timer = Time.time;
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Ennemie attaqué");
            enemy.GetComponent<Enemy>().TakeDamage(20);
        }
    }
}
