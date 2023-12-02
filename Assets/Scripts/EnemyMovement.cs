using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector2 movementVector = new Vector2(10f, 0f);

    private Tuple<float, float> _limit;
    private bool _hasChangedRecently = false;
    private float _offset = 0.1f;

    private float speedFactor = 2f;
    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
        FlipHorizontally();
        //Item1 Will be LeftLimit and Item2 RightLimit
        _limit = new Tuple<float, float>(startingPos.x - movementVector.x + _offset, startingPos.x + movementVector.x - _offset);

    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {

        float movementFactor = Mathf.Sin(Time.time * speedFactor);
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;

        if ((_limit.Item1 >= transform.position.x || _limit.Item2 <= transform.position.x) && !_hasChangedRecently)
        {
            _hasChangedRecently = true;
            FlipHorizontally();
        }

        if (_hasChangedRecently)
            StartCoroutine(WaitXTimeBeforeFlippingHorizontally());
        
    }

    IEnumerator WaitXTimeBeforeFlippingHorizontally()
    {
        yield return new WaitForSeconds(1.0f);
        _hasChangedRecently = false;
    }

    void FlipHorizontally()
    {
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
