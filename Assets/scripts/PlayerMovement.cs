using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 4f;
    public Rigidbody2D rb;

    Vector2 movement;


    SpriteRenderer sprite;

    Player player;


    public GameObject bullet;


    protected void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();


        print(GenerativeGrammar.Test());



    }


    // Update is called once per frame
    protected void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");



        if (Input.GetKeyDown(KeyCode.L))
        {


            //Instantiate(bullet, this.gameObject.transform.position + new Vector3(player.Flipped ? 1 : -1, 0, 0), Quaternion.AngleAxis(90,new Vector3(0,0,1))).GetComponent<Projectile>().Direction = new Vector3(player.Flipped ? 1 : -1,0,0) ;


            this.GetComponentsInChildren<Gun>(false)[0].Fire(new Vector3(player.Flipped ? 1 : -1, 0, 0));



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



}
