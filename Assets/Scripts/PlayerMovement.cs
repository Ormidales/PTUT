using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class PlayerMovement : Entity
{

    public float moveSpeed = 4f;
    public Rigidbody2D rb;

    Vector2 movement;


    SpriteRenderer sprite;


    protected override void Start()
    {
        base.Start();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();



    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if (movement.sqrMagnitude >= 1)
        {
            //sprite.flipX = movement.x < 0f;

            var sc = transform.localScale;

            var flip = movement.x > 0;

            if (flip != Flipped)
            {

                transform.localScale = new Vector3(sc.x*-1, sc.y, sc.z);

                Flipped = flip;

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