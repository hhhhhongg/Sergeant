using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NpcPatrol : MonoBehaviour
{
    private float speed = 5;
    public float movetoWaitTime;
    private float Wait = 0f;

    public Transform mySpot;

    public Transform ptrolPos;
    public Transform oldptrolPos;

    public Animator animator;

    public bool right = false;

    private void Awake()
    {
        mySpot = this.transform;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!right)
        {
            transform.position = Vector3.MoveTowards(transform.position, ptrolPos.position, speed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, ptrolPos.position);
            if (distance <= 0.1f)
            {

                Wait += Time.deltaTime;
                if (Wait >= movetoWaitTime)
                {
                    right = true;
                    Wait = 0;
                }
            }
        }
        else
        {
            animator.SetBool("Idle", false);
            transform.position = Vector3.MoveTowards(transform.position, oldptrolPos.position, speed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, oldptrolPos.position);
            if (distance <= 0.1f)
            {

                Wait += Time.deltaTime;
                if (Wait >= movetoWaitTime)
                {
                    right = false;
                    Wait = 0;
                }
            }
        }
        
    }
}
