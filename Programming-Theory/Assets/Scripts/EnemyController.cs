using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inheritance
public class EnemyController : Unit
{
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        
    }


    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        Move();
    }

    public override void Move()
    {
        Flip();
    }
}
