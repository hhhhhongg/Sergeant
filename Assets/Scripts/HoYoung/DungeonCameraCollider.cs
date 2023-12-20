using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DungeonCameraCollider : MonoBehaviour
{
    public delegate void CameraChangeEvent(Vector2 vector);

    public static event CameraChangeEvent ChangeCameraPosition;

    private static List<CameraChangeEvent> CameraHandlers = new List<CameraChangeEvent>();

    //private CameraChangeEvent TestEvent;
    private void Start()
    {
        //TestEvent += DungeonCameraController.instance.HandleCameraEvent;
    }
    public static void AddEventHandler(CameraChangeEvent handler)
    {
        CameraHandlers.Add(handler);
    }

    // 이벤트 핸들러 해제
    public static void RemoveEventHandler(CameraChangeEvent handler)
    {
        CameraHandlers.Remove(handler);
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            Debug.Log($"CameraCollider : {other} ");
            Vector2 roomVector = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

            foreach (var handler in CameraHandlers)
            {
                handler(roomVector);
            }
            //TestEvent(roomVector);
        }
    }
}
