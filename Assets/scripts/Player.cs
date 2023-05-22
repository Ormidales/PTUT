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
    public GameObject defenseItem;
    public Animator animator;

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
        animator.SetBool("End",true);
        PlayerMovement.instance.enabled=false;
        PlayerMovement.instance.playerCollider.enabled = false;
        StartCoroutine(end());

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

    public void setInvincible(float time)
    {
        StartCoroutine(invincibility(time));
        StartCoroutine(invincibilityUi());
    }

    public IEnumerator invincibility(float time)
    {
        isInvincible=true;
        defenseItem.SetActive(true);
        yield return new WaitForSeconds(time);
        defenseItem.SetActive(false);
        isInvincible=false;
    }

    public IEnumerator invincibilityUi()
    {
        while(isInvincible)
        {
            defenseItem.GetComponent<SpriteRenderer>().color  = new Color(0.5f,0.5f,0.7f,0.5f);
            defenseItem.GetComponent<Transform>().localScale -= new Vector3(0.2f, 0.2f, 0f);
            yield return new WaitForSeconds(0.2f);
            defenseItem.GetComponent<SpriteRenderer>().color = new Color(0.5f,0.5f,0.7f,0.4f);
            defenseItem.GetComponent<Transform>().localScale += new Vector3(0.2f, 0.2f, 0f);
            yield return new WaitForSeconds(0.2f);
        }
    }
    public IEnumerator end()
    {
        yield return new WaitForSeconds(1.1f);
        graphics.color = new Color(1f,1f,1f,0f);
        GameOverManager.instance.gameOver();
    }
}