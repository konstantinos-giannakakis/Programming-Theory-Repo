using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Polymorphism
    protected bool isFacingRight = true;
    protected float horizontal;

    private float m_speed = 0.5f;
    protected float speed { 
           get { return m_speed; }
           set {

            if (value > 3 || value < 1)
            {
                Debug.LogError("You can't set a a value like this for speed!");
            }
            else { m_speed = value; }

           } 
    }
    public virtual void Move()
    {
        
    }

    public virtual void Flip()
    {
        if (isFacingRight && horizontal > 0f || !isFacingRight && horizontal < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
