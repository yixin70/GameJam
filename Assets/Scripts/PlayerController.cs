using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed=6,jumpForce=5;
    [SerializeField] private int jumpCount;

    [SerializeField] private Transform groundCheck;

    private Rigidbody2D rb;  
    private Animator anim;
    private MyPhysics2D physics;

    private InputActions inputActions;
    private float horizontalMove;
    //Usar Nuevo sistema de Input de Unity para facilitar 
    private void Awake()
    {
        inputActions = new InputActions();
    }
    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Jump.started += Jump;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<MyPhysics2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        horizontalMove = inputActions.Player.Move.ReadValue<Vector2>().x;
    }
    private void FixedUpdate()
    {
        Run();
        Flip();
        SwitchAnimation();
        
    }

    private void SwitchAnimation()
    {
        if (rb.velocity.y<0)
        {
            this.anim.SetBool("Jump", false);
            this.anim.SetBool("Fall", true);
        }else if (rb.velocity.y > 0)
        {
            this.anim.SetBool("Jump", true);
            this.anim.SetBool("Fall", false);
        }
        if (physics.isGround)
        {
            this.anim.SetBool("Jump", false);
            this.anim.SetBool("Fall", false);
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (physics.isGround)
        {
            this.anim.SetBool("Jump", true);
            this.anim.SetBool("Fall", false);
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }

    }


    void Flip()
    {
        bool playerHasXMove = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasXMove)
        {
            if (rb.velocity.x > 0.01f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (rb.velocity.x < -0.01f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
    private void Run()
    {
        rb.AddForce(new Vector2(horizontalMove * moveSpeed, rb.velocity.y));
        bool playerHasXMove = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        this.anim.SetBool("Run", playerHasXMove);
    }
}
