using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector2 movementVector = new Vector2(10f, 10f);
    public float period = 2f;
    public bool isStop = false;
    private float speedFactor = 2f;
    private bool facingRight;

    public float movementFactor; // 0 for not moved, 1 for fully moved.

    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        movement();


    }

    void movement() {

        movementFactor = Mathf.Sin(Time.time * speedFactor);
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
        
    }
    void FlipHorizontally()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void detectDirection(float movementFactor , float movementFactorNew) {
        if (movementFactorNew > movementFactor)
            facingRight = false;
        else facingRight = true;

     
    }

}
