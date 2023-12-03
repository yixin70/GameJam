using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BunnyMovement : MonoBehaviour
{

    private float jumpForce = 5;
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
        speed = 0.5f;
        animator = GetComponent<Animator>();
        _FlipHorizontally();    
    }

    void Update()
    {
        _Intervalo();
        SwitchAnimation();
    }
    private void _Intervalo()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 1.5f)
        {
            _ChangeDirecction();

            elapsedTime = 0;
        }
        else if (elapsedTime >= 0.45f && elapsedTime <= 0.5f)
        {
            if (physics.isGround)
                _Jump();
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
        if (physics.isGround)
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }


    private void _Jump()
    {
        Debug.Log("Jumped");

        if (!_hasJumped)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            _hasJumped = true;
            StartCoroutine(_WaitXTimeBeforejumpingAgain());
        }
    }
    private void _FlipHorizontally()
    {
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private IEnumerator _WaitXTimeBeforejumpingAgain()
    {
        yield return new WaitForSeconds(1.0f);
        _hasJumped = false;
    }

    private void SwitchAnimation()
    {

        if (rb.velocity.y < 0)
        {
            this.animator.SetBool("jumping", false);
           this.animator.SetBool("falling", true);
           this.animator.SetBool("isGrounded", false);
       }
       else if (rb.velocity.y > 0)
       {
           this.animator.SetBool("jumping", true);
           this.animator.SetBool("falling", false);
           this.animator.SetBool("isGrounded", false);
       }
       if (physics.isGround)
       {
           this.animator.SetBool("jumping", false);
           this.animator.SetBool("falling", false);
           this.animator.SetBool("isGrounded", true);
       }            


    }



}
