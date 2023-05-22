using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;

    public float range = 1f;

    private float timeBetweenAttack = 0.75f;
    private float timer = 0;

    public Animator animator;

    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Attack",false);
        if(Input.GetKeyDown(KeyCode.F) && Time.time - timer > timeBetweenAttack)
        {
            animator.SetBool("Attack",true);
            Attack();
            timer = Time.time;
        }
        ChangeAttackSide();
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
    private void ChangeAttackSide()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && attackPoint.localPosition.x < 0)
        {
            attackPoint.localPosition = new Vector2(Math.Abs(attackPoint.localPosition.x), attackPoint.position.y);
        }else if(Input.GetKeyDown(KeyCode.LeftArrow) && attackPoint.localPosition.x > 0)
        {
            attackPoint.localPosition = new Vector2(-attackPoint.localPosition.x, attackPoint.position.y);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, range);
    }
}
