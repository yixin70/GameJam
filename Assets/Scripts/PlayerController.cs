using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float initialMoveSpeed=8,initialJumpForce=3;
    private float moveSpeed, jumpForce;
    [SerializeField] private int jumpCount;

    private Rigidbody2D rb;  
    private Animator anim;
    private MyPhysics2D physics;

    public InputActions inputActions;
    private float horizontalMove;

    public Vector3 scale;
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

    void Start()
    {
        physics = GetComponent<MyPhysics2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scale = transform.localScale;
        jumpForce = initialJumpForce;
        moveSpeed= initialMoveSpeed;
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
        ChangScale();
    }
    private void ChangScale()
    {
        if (transform.localScale.x == scale.x) return;
        transform.localScale = Vector3.MoveTowards(transform.localScale, scale, Time.deltaTime);
        jumpForce=initialJumpForce*scale.x;
        moveSpeed=initialMoveSpeed*scale.x;
        rb.mass = 1+scale.x/4;
        physics.groundMaterial.friction = 0.4f * scale.x;

    }

    private void SwitchAnimation()
    {
        if(!physics.isGround)
        {
            if (rb.velocity.y < 0.01)
            {
                this.anim.SetBool("Jump", false);
                this.anim.SetBool("Fall", true);
            }
            else if (rb.velocity.y > 0.01)
            {
                this.anim.SetBool("Fall", false);
                if (jumpCount == 1)
                {
                    this.anim.SetBool("Jump", true);
                }
                else if (jumpCount == 2)
                {
                    this.anim.SetTrigger("DoubleJump");
                }
            }
        }
        if (physics.isGround && rb.velocity.y == 0)
        {
            this.anim.SetBool("Jump", false);
            this.anim.SetBool("Fall", false);
            jumpCount = 0;
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (physics.isGround || jumpCount<2)
        {
            if (jumpCount == 0)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                jumpCount++;
            }else if(jumpCount == 1) {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                jumpCount++;
            }
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
        bool playerHasXMove = Mathf.Abs(rb.velocity.x) >0.01f;
        this.anim.SetBool("Run", playerHasXMove);
    }
}
