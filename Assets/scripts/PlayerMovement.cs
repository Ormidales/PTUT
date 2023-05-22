using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public Rigidbody2D rb;
    public BoxCollider2D playerCollider;

    public static PlayerMovement instance;
    
    private void Awake()
    {
        if (instance!=null)
        {
            UnityEngine.Debug.LogWarning("Only one instance of PlayerMovement is expected !");
            return;
        }
        instance = this;
    }

    Vector2 movement;


    SpriteRenderer sprite;

    Player player;


    public GameObject bullet;


    protected void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    protected void Update()
    {
        movement.x = Input.GetKey(UIController.Left) ? -1 : Input.GetKey(UIController.Right) ? 1 : 0; //Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetKey(UIController.Up) ? 1 : Input.GetKey(UIController.Down) ? -1 : 0;



        if (Input.GetKeyDown(UIController.Shoot))
        {


            //Instantiate(bullet, this.gameObject.transform.position + new Vector3(player.Flipped ? 1 : -1, 0, 0), Quaternion.AngleAxis(90,new Vector3(0,0,1))).GetComponent<Projectile>().Direction = new Vector3(player.Flipped ? 1 : -1,0,0) ;

            
            try{
                this.GetComponentsInChildren<Gun>(false)[0].Fire(new Vector3(player.Flipped ? 1 : -1, 0, 0));
            }catch (Exception){
                UnityEngine.Debug.LogWarning("Pas d'arme");
            }
            AudioManager.Instance.PlaySFX("shot");

        }


        if(Input.GetKeyDown(KeyCode.P))
        {
            MenuPauseManager.instance.menuPause();  
            Time.timeScale = 0; 
        }


        if (movement.sqrMagnitude >= 1)
        {
            //sprite.flipX = movement.x < 0f;

            var sc = transform.localScale;

            var flip = movement.x > 0;

            if (flip != player.Flipped)
            {

                transform.localScale = new Vector3(sc.x * -1, sc.y, sc.z);

                player.Flipped = flip;

            }








        }



    }




    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }



    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("trigger");
        }
    }


    public void speedBuffAction(int speed, float time){
        StartCoroutine(speedBuff(speed,time));
    }

    private IEnumerator speedBuff(int speed, float time)
    {
        moveSpeed+=speed;
        yield return new WaitForSeconds(time);
        moveSpeed-=speed;
    }



}