using System;
using System.Collections;
using UnityEngine;

public class MyPhysics2D : MonoBehaviour
{
    [Header("CheckIsColision")]
    public bool isColision;
    public float checkRadius;
    public Vector2 checkOffset;
    public LayerMask checkLayer;
    [SerializeField]public PhysicsMaterial2D groundMaterial; 

    private void Update()
    {
        CheckIsGround();
    }

    private void CheckIsGround()
    {
        isColision=Physics2D.OverlapCircle((Vector2)transform.position+checkOffset,checkRadius,checkLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + checkOffset, checkRadius);
    }
}
