using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public TMP_Text userMoney;

    public ItemStats[] itemStats;

    public Image[] image;   // 아이템 이미지
    public TMP_Text[] itemName;   // 아이템 이름
    public TMP_Text[] itemPrice;    // 아이템 가격

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
        // userMoney.text = Player에 소지금을 불러온다.

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
        // 이미지를 눌렀을 때 구매하려는 아이템으 정보를 표시

        // 데이터 받아오기
        Debug.Log("클릭한 아이템: " + itemIndex);

        infoItem_Image.sprite = itemStats[itemIndex].itemImage;
        infoItem_name.text = itemStats[itemIndex].itemName;
        infoItem_explan.text = itemStats[itemIndex].explan;
        infoItem_price.text = itemStats[itemIndex].price.ToString();
        infoItem_atk.text = itemStats[itemIndex].atk.ToString();
        infoItem_def.text = itemStats[itemIndex].def.ToString();
        infoItem_spd.text = itemStats[itemIndex].spd.ToString();
        infoItem_hp.text = itemStats[itemIndex].hp.ToString();
    }

    void BuyItem()
    {
        // 구매
        // PlayerMoney.Text = 
    }
}


