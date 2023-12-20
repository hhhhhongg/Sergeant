using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shild : MonoBehaviour
{
    public Collider2D Collider;
    public TopDownMovement playerTopDown;

    private void Awake()
    {
        Collider = GetComponent<Collider2D>();
        playerTopDown = GetComponentInParent<TopDownMovement>();
    }

    private void Update()
    {
        if(playerTopDown._isDash)
        { 
            Collider.enabled = true;
        }
        else
        {
            Collider.enabled=false;
        }
    }
}
