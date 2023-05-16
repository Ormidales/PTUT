using UnityEngine;
using System.Collections;

public class Player : Entity
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isInvincible=false;
    public float invicibilityFlash=0.1f;
    public float invicibilityTime=1f;
    public SpriteRenderer graphics;

    public static Player instance;
    
    private void Awake()
    {
        if (instance!=null)
        {
            UnityEngine.Debug.LogWarning("Only one instance of Player is expected !");
            return;
        }
        instance = this;
    }
    
    
    public override void Start()
    {
        currentHealth = DataManager.vie;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    public override void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(100);
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            MenuPauseManager.instance.menuPause();  
            Time.timeScale = 0; 
        }
        healthBar.SetHealth(currentHealth);
    }

    

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            if (currentHealth<=0){
                healthBar.SetHealth(0);
                Die();
                return;
            }
            else{
                healthBar.SetHealth(currentHealth);
                isInvincible=true;
                StartCoroutine(invincibilityFlash());
                StartCoroutine(handleInvincibilityDelay());
            }

        }
        
    }

    public void HealPlayer(int amount)
    {
        if (currentHealth+amount>=maxHealth){
            currentHealth=maxHealth;
        }else{
            currentHealth+=amount;
        }
    }

    public override void Die()
    {
        PlayerMovement.instance.enabled=false;
        PlayerMovement.instance.playerCollider.enabled = false;
        isInvincible=true;
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