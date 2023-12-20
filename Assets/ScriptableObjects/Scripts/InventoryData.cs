using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "myItems", menuName = "TopDownController/InventoryData", order = 2)]
public class InventoryData : ScriptableObject
{
    public List<ItemStats> myItems;
}
