using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
  
    Vector2 movement;

    

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }

    void FixedUpdate()
    {
        Move();
    }

    void onTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Trigger !");
    }
}
