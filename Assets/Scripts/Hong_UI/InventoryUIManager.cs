using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public ItemSlot[] itemslots;

    public void SetInventory()
    {
        for (int i = 0; i < DataManager.instance.inventoryData.myItems.Length; i++)
        {
            itemslots[i].Init(DataManager.instance.inventoryData.myItems[i]);
        }
    }
}
