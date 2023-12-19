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

    public void PopupSetting(ItemSlot slot)
    {
        if (slot.inputData != null)
        {
            if (slot.inputData.isEquips)
            {
                infoText.text = "������ �����Ͻðڽ��ϱ�?";
                confirmBtn.onClick.RemoveAllListeners();
                confirmBtn.onClick.AddListener(() =>
                {
                    slot.inputData.isEquips = false;
                    slot.ChangeEquip();
                });
            }
            else
            {
                infoText.text = "���� �Ͻðڽ��ϱ�?";
                confirmBtn.onClick.RemoveAllListeners();
                confirmBtn.onClick.AddListener(() =>
                {
                    slot.inputData.isEquips = true;
                    slot.ChangeEquip();
                });
            }
        }
        else
        {
            PopupEquipUI.SetActive(false);
        }
    }
}
