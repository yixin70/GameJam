using System;
using System.Collections;
using UnityEngine;

public class MyPhysics2D : MonoBehaviour
{
    [Header("CheckIsCollision")]
    public Collider2D collision;
    public float checkGroundRadius=0.2f;
    public Vector2 checkGroundOffset;
    public LayerMask checkLayers;


    private void Update()
    {
        CheckIsGround();
    }

    private void CheckIsGround()
    {
        collision = Physics2D.OverlapCircle((Vector2)transform.position+checkGroundOffset,checkGroundRadius,checkLayers);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + checkGroundOffset, checkGroundRadius);
    }
}
