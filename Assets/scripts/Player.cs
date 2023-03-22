using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isInvincible=false;
    public float invicibilityFlash=0.1f;
    public float invicibilityTime=2f;
    public SpriteRenderer graphics;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(100);
        }
    }

    

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            if (currentHealth<=0){
                healthBar.SetHealth(0);
                Die();
            }
            else{
                healthBar.SetHealth(currentHealth);
                isInvincible=true;
                StartCoroutine(invincibilityFlash());
                StartCoroutine(handleInvincibilityDelay());
            }

        }
        
    }
    public void Die()
    {
        ChaseAI.instance.setChaseActive(false);
        PlayerMovement.instance.setMovementActive(false);
        GameOverManager.instance.gameOver();
    }
    public IEnumerator invincibilityFlash()
    {
        while(isInvincible)
        {
            graphics.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(invicibilityFlash);
            graphics.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invicibilityFlash);
        }
    }
    public IEnumerator handleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTime);
        isInvincible=false;
    }
}