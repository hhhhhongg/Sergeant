using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log($"Destroyer : {other} ");
        if ((other.tag != "Player") && (other.tag != "Arrow")) 
        { 
            Destroy(other.gameObject); 
        }
    }
}
