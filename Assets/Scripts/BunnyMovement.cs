using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BunnyMovement : MonoBehaviour
{ 
    
    private Rigidbody2D rb;
    private float jumpForce = 100000000000000;
    float elapsedTime = 0;
    public float speed; 

    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        intervalo();
        _Movement();
        
    }
    private void intervalo() {
        elapsedTime += Time.deltaTime;
        _Movement();
        if (elapsedTime >= 1.5f)
        {
            _ChangeDirecction();
            elapsedTime = 0;
            _FlipHorizontally();
            Jump();
        }
         
    } 
    private void _ChangeDirecction() {
        speed *= -1;
    }
    private void _Movement()
    {
         
        rb.velocity = new Vector2(speed, 0);
    }
    
    
    private void Jump()
    {
        Debug.Log("Jumped");
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

    }
    private void _FlipHorizontally()
    {
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
