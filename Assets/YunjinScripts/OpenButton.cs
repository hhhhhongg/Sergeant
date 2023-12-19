using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{
    public GameObject obj;

    public void OpenGameObject()
    {
        obj.SetActive(true);
    }
}
