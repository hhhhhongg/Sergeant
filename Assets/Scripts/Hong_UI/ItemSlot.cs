using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [HideInInspector] public ItemStats inputData;

    public PopupEquip popupEquip;
    public Image itemImage;
    public GameObject equipMark;

    public void Init(ItemStats item)
    {
        inputData = item;
        itemImage.sprite = item.itemImage;
        itemImage.enabled = true;
        ChangeEquip();
    }

    public void ChangeEquip()
    {
        if (inputData.isEquips)
        {
            equipMark.SetActive(true);
        }
        else
        {
            equipMark.SetActive(false);
        }
    }

    public void Popup()
    {
        popupEquip.PopupSetting(this);
    }
}
