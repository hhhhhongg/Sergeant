using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupEquip : MonoBehaviour
{
    public TMP_Text infoText;
    public Button confirmBtn;
    public GameObject PopupEquipUI;
    public TMP_Text itemAtk;
    public TMP_Text itemDef;
    public TMP_Text itemSpd;
    public TMP_Text itemHp;
    public Image itemImage;

    public void PopupSetting(ItemSlot slot)
    {
        if (slot.inputData != null)
        {
            ItemInfoUpdate(slot);   
            if (slot.inputData.isEquips)
            {
                infoText.text = "장착을 해제하시겠습니까?";
                confirmBtn.onClick.RemoveAllListeners();
                confirmBtn.onClick.AddListener(() =>
                {
                    slot.inputData.isEquips = false;
                    slot.ChangeEquip();
                    InventoryUIManager.instance.SubCharacterStat(slot.inputData.atk, slot.inputData.def, slot.inputData.spd, slot.inputData.hp);
                    CharacterStatsHandler.instance.SetCharacterStats();
                });
            }
            else
            {
                infoText.text = "장착 하시겠습니까?";
                confirmBtn.onClick.RemoveAllListeners();
                confirmBtn.onClick.AddListener(() =>
                {
                    slot.inputData.isEquips = true;
                    slot.ChangeEquip();
                    InventoryUIManager.instance.SumCharacterStat(slot.inputData.atk, slot.inputData.def, slot.inputData.spd, slot.inputData.hp);
                    CharacterStatsHandler.instance.SetCharacterStats();
                });
            }
        }
        else
        {
            PopupEquipUI.SetActive(false);
        }
    }

    public void ItemInfoUpdate(ItemSlot slot)
    {
        itemAtk.text = slot.inputData.atk.ToString();
        itemDef.text = slot.inputData.def.ToString();
        itemSpd.text = slot.inputData.spd.ToString();
        itemHp.text = slot.inputData.hp.ToString();
        itemImage.sprite = slot.inputData.itemImage;
        itemImage.enabled = true;
    }
    
}
