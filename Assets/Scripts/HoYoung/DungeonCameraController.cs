using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DungeonCameraController : MonoBehaviour
{
    public static DungeonCameraController instance;
    public GameObject cameraFollowingOBJ;
    public GameObject MiniMapCamera;
    // Start is called before the first frame update
    void Start()
    {
        DungeonCameraCollider.AddEventHandler(HandleCameraEvent);
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        DungeonCameraCollider.RemoveEventHandler(HandleCameraEvent);
    }

    public void HandleCameraEvent(Vector2 vector)
    {
        Debug.Log($"Camera Position : {vector}");
        cameraFollowingOBJ.transform.position = new Vector3(vector.x, vector.y, -10);
        MiniMapCamera.transform.position = new Vector3(vector.x, vector.y, MiniMapCamera.transform.position.z);
    }

    //에디터에서 바로 실행하면 드래그 앤 드롭이 그대 작동되지만
    //스크립트로 새로 로드된 신은 드래그 앤 드롭
}
