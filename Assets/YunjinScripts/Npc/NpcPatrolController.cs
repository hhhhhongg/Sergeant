using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPatrolController : MonoBehaviour
{
    private float speed = 500;
    public float movetoWaitTime;
    private float Wait;

    public Rigidbody2D Rigidbody2D;

    public Transform mySpot;
    public Vector3 moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Awake()
    {
        mySpot = this.transform;
        Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        Wait = movetoWaitTime;
        moveSpot = new Vector3(mySpot.position.x + Random.Range(minX, maxX), mySpot.position.y + Random.Range(minY, maxY), 0);
       
    }

    private void Update()
    {
        Vector3 dir = (moveSpot - mySpot.position).normalized;
        Rigidbody2D.velocity = dir * speed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, moveSpot);
        if (distance <= 0.1f)
        {
            Rigidbody2D.velocity = Vector3.zero;
            Wait += Time.deltaTime;
            if(Wait >= movetoWaitTime)
            {
                moveSpot = new Vector3(mySpot.position.x + Random.Range(minX, maxX), mySpot.position.y + Random.Range(minY, maxY), 0);
                Wait = 0;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //moveSpot = transform.position;
        //moveSpot = new Vector3(mySpot.position.x + Random.Range(minX, maxX), mySpot.position.y + Random.Range(minY, maxY), 0);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("12");
        moveSpot = transform.position;
    }
}
