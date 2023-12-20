using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DungeonCameraController : MonoBehaviour
{
    public GameObject cameraFollowingOBJ;
    public GameObject MiniMapCamera;
    // Start is called before the first frame update
    void Start()
    {
        DungeonCameraCollider.AddEventHandler(HandleCameraEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleCameraEvent(Vector2 vector)
    {
        Debug.Log($"Camera Position : {vector}");
        cameraFollowingOBJ.transform.position = new Vector3(vector.x, vector.y, -10);
        MiniMapCamera.transform.position = new Vector3(vector.x, vector.y, MiniMapCamera.transform.position.z);
    }
}
