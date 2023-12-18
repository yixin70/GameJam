using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private MyPhysics2D physics;

    private float elapsedTime = 0;
    public float speed;
    public float agroRange;
    public Transform frog;

    private Animator animator;

    private int _turtleGoingRight = 1; //Si es 1, entonces la tortuga va a la derecha, si es -1 va a la izquierda.
    private int _previousStateTurtleGoingRight = 1; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        physics = GetComponent<MyPhysics2D>();
       
        animator = GetComponent<Animator>();
        _FlipHorizontally();
         
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_IsAggro())
        {
            if(frog.transform.position.x <= transform.position.x)
            {
                _turtleGoingRight = -1; //Significa que la rana esta a la izquierda de la tortuga.
            }
            else
            {
                _turtleGoingRight = 1; //Al reves.
            }

            _Movement();
        }

        //YIXIN:
        //Si el estado previo es distinto del actual, significa que se tiene que dar la vuelta.
        //Tambien actualizamos el estado previo al actual.
        if(_previousStateTurtleGoingRight != _turtleGoingRight)
        {
            _FlipHorizontally();
            _previousStateTurtleGoingRight = _turtleGoingRight;
        }

        _SwitchAnimation();

    }

    private void _FlipHorizontally()
    {
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;


        transform.localScale = Scaler;
    }
    private void _Movement()
    {
        if (physics.isGround)
        {
            //Aqui multiplico el valor ese por la velocidad y asi determina automaticamente si tiene que ir a la derecha o la izquierda
            rb.velocity = new Vector2(speed * _turtleGoingRight, 0); 
        }

    }
    private bool _IsAggro() {

        return Vector2.Distance(transform.position, frog.position) < agroRange;
        
    }

    private void _SwitchAnimation()
    {

        if (_IsAggro())
        {
            this.animator.SetBool("Agro", true);

        }
        else this.animator.SetBool("Agro", false);

    }

}
