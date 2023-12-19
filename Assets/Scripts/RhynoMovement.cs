using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhynoMovement : MonoBehaviour
{
    private float elapsedTime = 0;
    public float speed;

    private Rigidbody2D rb;
    private MyPhysics2D physics;

    private bool _hasJumped = false;
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        physics = GetComponent<MyPhysics2D>();
        
        animator = GetComponent<Animator>();
        _FlipHorizontally();
    }

    void Update()
    {
        _Intervalo();
       
    }
    private void _Intervalo()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 1.5f)
        {
            _ChangeDirecction();

            elapsedTime = 0;
        }
        
        else
        {
            _Movement();
        }

    }
    private void _ChangeDirecction()
    {
        speed *= -1;
        _FlipHorizontally();
    }
    private void _Movement()
    {
        if (physics.isCollision)
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }
    private void _FlipHorizontally()
    {
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
