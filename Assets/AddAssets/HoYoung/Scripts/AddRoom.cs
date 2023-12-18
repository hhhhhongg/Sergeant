using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour {

	private RoomTemplates templates;

	void Start(){
		Debug.Log($"AddRoom : {this.gameObject}");
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		templates.rooms.Add(this.gameObject);
	}
}
