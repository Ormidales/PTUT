using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 4f;
    public Rigidbody2D rb;
    public BoxCollider2D playerCollider;

    Vector2 movement;
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
