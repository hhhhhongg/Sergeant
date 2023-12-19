using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager instance;
    public ItemSlot[] itemslots;
    public TMP_Text atk;
    public TMP_Text def;
    public TMP_Text spd;
    public TMP_Text hp;
    

    private void Awake()
    {
        instance = this;
    }
    public void SetInventory()
    {
        for (int i = 0; i < DataManager.instance.inventoryData.myItems.Length; i++)
        {
            itemslots[i].Init(DataManager.instance.inventoryData.myItems[i]);
        }
    }

    public void SetCharacterStat()
    {
        atk.text = DataManager.instance.userData.atk.ToString();
        def.text = DataManager.instance.userData.def.ToString();
        spd.text = DataManager.instance .userData.spd.ToString();
        hp.text = DataManager .instance .userData.hp.ToString();
    }
    

    public void SumCharacterStat(int atk, int def, int spd, int hp)
    {
        DataManager.instance.userData.atk += atk;
        DataManager.instance.userData.def += def;
        DataManager.instance.userData.spd += spd;
        DataManager.instance.userData.hp += hp;
        SetCharacterStat();
    }
    public void SubCharacterStat(int atk, int def, int spd, int hp)
    {
        DataManager.instance.userData.atk -= atk;
        DataManager.instance.userData.def -= def;
        DataManager.instance.userData.spd -= spd;
        DataManager.instance.userData.hp -= hp;
        SetCharacterStat();
    }

   
}
