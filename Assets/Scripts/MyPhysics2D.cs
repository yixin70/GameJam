using System;
using System.Collections;
using UnityEngine;

public class MyPhysics2D : MonoBehaviour
{
    [Header("CheckIsCollision")]
    public bool isCollision;
    public float checkGroundRadius=0.2f;
    public Vector2 checkGroundOffset;
    public LayerMask checkLayers;
    [SerializeField]public PhysicsMaterial2D groundMaterial; 


    private void Update()
    {
        CheckIsGround();
    }

    private void CheckIsGround()
    {
        isCollision=Physics2D.OverlapCircle((Vector2)transform.position+checkGroundOffset,checkGroundRadius,checkLayers);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + checkGroundOffset, checkGroundRadius);
    }
}
