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
    public static PlayerMovement instance;
    private bool movementActive=true;
    
    private void Awake()
    {
        if (instance!=null)
        {
            UnityEngine.Debug.LogWarning("Only one instance of PlayerMovement is expected !");
            return;
        }
        instance = this;
    }

    public void setMovementActive(bool boolean)
    {
        movementActive=boolean;
    }
    // Update is called once per frame
    void Update()
    {
        if (movementActive)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        } 
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
