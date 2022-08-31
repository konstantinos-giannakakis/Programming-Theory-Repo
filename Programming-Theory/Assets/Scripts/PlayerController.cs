using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inheritance
public class PlayerController : Unit
{
    private Animator playerAnim;
    private float jumpingPower = 3f;
    private bool isOnGround;
    private bool gameOver = false;

    // Encapsulation
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Encapsulation 
        // If we run the following line we get the appropriate error
        //speed *= 2;
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    void Update()
    {
        // Abstraction
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameOver = true;
        } else if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            isOnGround = true;
        }
        
        

    }

    // Polymorphism
    public override void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown("space") && isOnGround && !gameOver)
        {
            isOnGround = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetKeyUp("space") && rb.velocity.y > 0f && !gameOver)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }
}