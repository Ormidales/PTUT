using UnityEngine;
using System.Collections;
using System;

public class Player : Entity
{
    

    public Player() {
        HealthTop = 100;

    }

    PlayerMovement playerMovement;

    public HealthBar healthBar;
    public bool isInvincible=false;
    public float invicibilityFlash=0.1f;
    public float invicibilityTime=2f;
    public SpriteRenderer graphics;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerMovement = GetComponent<PlayerMovement>();
        healthBar.SetMaxHealth(HealthTop);
        OnHealthChanged += (data) => {
            healthBar.SetHealth(data.Health);
        };
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Damage(100,null);
        }
    }

    


    public override void Damage(int damage,Entity x)
    {
        if (!isInvincible)
        {
            Health -= damage;
            AudioManager.Instance.PlaySFX("player_hurt");
            if (Health<=0){
                Die();
            }
            else{
                isInvincible=true;
                StartCoroutine(invincibilityFlash());
                StartCoroutine(handleInvincibilityDelay());
            }

        }
        
    }
    public void Die()
    {
        // TODO
        playerMovement.enabled=false;
        //playerMovement.rb = false;
        isInvincible=true;
        GameOverManager.instance.gameOver();
        AudioManager.Instance.PlaySFX("player_die");

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