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



    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }

   

    void OnTriggerEnter2D (Collider2D trigger )
    {
        if (trigger.CompareTag("Player")) {
            UnityEngine.Debug.Log("trigger");
        }
    }

    
    
}
