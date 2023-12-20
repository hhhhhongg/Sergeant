using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    UserData userdata;
    public TMP_Text userMoney;
    int buyMoney = 0;

    public ItemStats[] itemStats;
    
    public Image[] image;   // ������ �̹���
    public TMP_Text[] itemName;   // ������ �̸�
    public TMP_Text[] itemPrice;    // ������ ����

    public Image infoItem_Image;
    public TMP_Text infoItem_name;
    public TMP_Text infoItem_explan;
    public TMP_Text infoItem_price;
    public TMP_Text infoItem_atk;
    public TMP_Text infoItem_def;
    public TMP_Text infoItem_spd;
    public TMP_Text infoItem_hp;

    private void Start()
    {
        userMoney.text = DataManager.instance.userData.gold.ToString();

        DisplayItems();
    }

    void DisplayItems()
    {
        if(itemStats != null && image != null)
        {
            for( int i = 0; i < image.Length; i++)
            {
                image[i].sprite = itemStats[i].itemImage;
                itemName[i].text = itemStats[i].itemName;
                itemPrice[i].text = itemStats[i].price.ToString();

                Button btn = image[i].GetComponent<Button>();
                int index = i;
                btn.onClick.AddListener(() => OnButtonClick(index));
            }
        }
    }

    void OnButtonClick(int itemIndex)
    {
        // �̹����� ������ �� �����Ϸ��� �������� ������ ǥ��

        // ������ �޾ƿ���
        Debug.Log("Ŭ���� ������: " + itemIndex);

        infoItem_Image.sprite = itemStats[itemIndex].itemImage;
        infoItem_name.text = itemStats[itemIndex].itemName;
        infoItem_explan.text = itemStats[itemIndex].explan;
        infoItem_price.text = itemStats[itemIndex].price.ToString();
        infoItem_atk.text = itemStats[itemIndex].atk.ToString();
        infoItem_def.text = itemStats[itemIndex].def.ToString();
        infoItem_spd.text = itemStats[itemIndex].spd.ToString();
        infoItem_hp.text = itemStats[itemIndex].hp.ToString();
    }

    public void BuyItem()
    {
        // ������ ������ ����
        buyMoney = int.Parse(infoItem_price.text);
        // ������ ���
        userMoney.text = (int.Parse(userMoney.text) - buyMoney).ToString();
        // ������ �ٲٱ�
        DataManager.instance.userData.gold = int.Parse(userMoney.text);
    }
}


