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

    //�����Ϳ��� �ٷ� �����ϸ� �巡�� �� ����� �״� �۵�������
    //��ũ��Ʈ�� ���� �ε�� ���� �巡�� �� ���
}
