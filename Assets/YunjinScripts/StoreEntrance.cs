using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreEntrance : MonoBehaviour
{
    public GameObject entrance;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        entrance.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            entrance.SetActive(false);
    }
    
}
