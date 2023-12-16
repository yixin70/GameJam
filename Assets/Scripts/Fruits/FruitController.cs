using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    private Animator anim;
    public FruitType fruitType;
     
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void CollectFruit()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1);
        anim.SetTrigger("Collect"); 
    }
}

