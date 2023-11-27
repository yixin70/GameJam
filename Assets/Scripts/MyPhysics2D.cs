using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPhysics2D : MonoBehaviour
{
    [Header("CheckIsGround")]
    public bool isGround;
    public float checkGroundRadius;
    public Vector2 checkGroundOffset;
    public LayerMask groundLayer;

    private void Awake()
    {
        groundLayer = LayerMask.GetMask("Ground");
    }
    private void Update()
    {
        CheckIsGround();
    }

    private void CheckIsGround()
    {
        isGround=Physics2D.OverlapCircle((Vector2)transform.position+checkGroundOffset,checkGroundRadius,groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + checkGroundOffset, checkGroundRadius);
    }
}
