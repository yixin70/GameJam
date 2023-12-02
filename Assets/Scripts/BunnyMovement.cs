using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BunnyMovement : MonoBehaviour
{

    public Vector2 movementVector = new Vector2(5f, 0f);

    private Tuple<float, float> _limit;
    private bool _hasChangedRecently = false;
    private float _offset = 0.1f;

    private float _speedFactor = 0.5f;
    private Vector3 _startingPos;

    void Start()
    {
        _startingPos = transform.position;
        _FlipHorizontally();
        //Item1 Will be LeftLimit and Item2 RightLimit
        _limit = new Tuple<float, float>(_startingPos.x - movementVector.x + _offset, _startingPos.x + movementVector.x - _offset);
    }

    void Update()
    {
        _Movement();
    }

    private void _Movement()
    {
        float movementFactor = 2.0f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = _startingPos + offset;

        if ((_limit.Item1 >= transform.position.x || _limit.Item2 <= transform.position.x) && !_hasChangedRecently)
        {
            _hasChangedRecently = true;
            _FlipHorizontally();
        }

        if (_hasChangedRecently)
            StartCoroutine(_WaitXTimeBeforeFlippingHorizontally());

    }

    private IEnumerator _WaitXTimeBeforeFlippingHorizontally()
    {
        yield return new WaitForSeconds(1.0f);
        _hasChangedRecently = false;
    }

    private void _FlipHorizontally()
    {
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
