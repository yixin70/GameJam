using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonAnim : MonoBehaviour
{
    public float maxSize, minSize,scaledSpeed;
    private Vector3 maxTarget, minTarget;
    private bool change;
    void Start()
    {
        change = false;
        maxTarget = new Vector3(maxSize, maxSize, maxSize);
        minTarget= new Vector3(minSize,minSize,minSize);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x < maxSize&&change)
        {
            transform.localScale= Vector3.MoveTowards(transform.localScale, maxTarget, scaledSpeed * Time.deltaTime);
            
        }
        else if(transform.localScale.x > minSize&&!change)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, minTarget, scaledSpeed * Time.deltaTime);
        }
        if(transform.localScale.y >= maxSize||transform.localScale.y <= minSize)
        {
            change = !change;
        }
    }
}
