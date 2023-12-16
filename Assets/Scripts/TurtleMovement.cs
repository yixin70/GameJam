using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;
    private MyPhysics2D physics;

    private float elapsedTime = 0;
    public float speed;
    public float agroRange;
    public Transform frog;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        physics = GetComponent<MyPhysics2D>();
        speed = 2f;
        animator = GetComponent<Animator>();
        _FlipHorizontally();
        agroRange = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        _IntervaloMovement();
        if (isAgro()) Debug.Log("ASAAAAAAAAAAAAAAAAAAAAAAA");


    }

    private void _FlipHorizontally()
    {
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void _ChangeDirecction()
    {
        speed *= -1;
        _FlipHorizontally();
    }
    private void _Movement()
    {
        if (physics.isGround)
            rb.velocity = new Vector2(speed, 0);

    }
    private void _IntervaloMovement()
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
    private bool isAgro() {

        return Vector2.Distance(transform.position, frog.position) < agroRange;
        
    }

    private void SwitchAnimation()
    {

        if (isAgro())
        {
            this.animator.SetBool("Agro", true);

        }
        else this.animator.SetBool("Agro", false);




    }

}
