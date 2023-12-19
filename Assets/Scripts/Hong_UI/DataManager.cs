using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public UserData userData;
    public InventoryData inventoryData;

    private void Awake()
    {
        instance = this;
    }

}
