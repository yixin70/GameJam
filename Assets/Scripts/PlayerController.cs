using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float initialMoveSpeed=60,initialJumpForce=40,scaledSpeed=1;
    [SerializeField] private int jumpCount,initialHealth;
    private float horizontalMove, moveSpeed, jumpForce;
    public int health;
    private Vector3 scale;
    
    public InputActions inputActions;
    public Rigidbody2D rb;  
    public Animator animator;
    private MyPhysics2D physics;
    public AudioSource audioSource;

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
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        health=initialHealth;
        scale = transform.localScale;
        this.SetScale();
    }

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
    public void ChangScale(float power)
    {
        scale = new Vector3(power, power, 1);
    }
    private void ChangScale()
    {
        if (transform.localScale.x == scale.x) return;
        transform.localScale = Vector3.MoveTowards(transform.localScale, scale, scaledSpeed * Time.deltaTime);
        this.SetScale();
    } 
    
    private void SetScale()
    {
        jumpForce=initialJumpForce*scale.x;
        moveSpeed=initialMoveSpeed*scale.x;
        physics.groundMaterial.friction = 0.3f * scale.x;
    }
    private void SwitchAnimation()
    {
        if(!physics.isCollision)
        {
            if (rb.velocity.y < 0.01)
            {
                this.animator.SetBool("Jump", false);
                this.animator.SetBool("Fall", true);
            }
            else if (rb.velocity.y > 0.01)
            {
                this.animator.SetBool("Fall", false);
                if (jumpCount == 1)
                {
                    this.animator.SetBool("Jump", true);
                }
                else if (jumpCount == 2)
                {
                    this.animator.SetTrigger("DoubleJump");
                }
            }
        }
        if (physics.isCollision && rb.velocity.y == 0)
        {
            this.animator.SetBool("Jump", false);
            this.animator.SetBool("Fall", false);
            jumpCount = 0;
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
        this.animator.SetBool("Run", playerHasXMove);
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (physics.isCollision|| jumpCount < 2)
        {
            if (jumpCount == 0)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                jumpCount++;
            }
            else if (jumpCount == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                jumpCount++;
            }
        }
    }

    public void ManageDeath()
    {
        transform.position = GameManager.Instance.activeCheckpoint.transform.position;
        health = initialHealth;
    }


}
