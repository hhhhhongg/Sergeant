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

    private void Start()
    {
        // userMoney = Player에 소지금을 불러온다.

        DisplayItems();
    }

    void DisplayItems()
    {
        if(itemStats != null && image != null)
        {
            for( int i = 0; i < image.Length; i++)
            {
                itemIconView(image[i], itemStats[i], itemName[i], itemPrice[i]);
            }
        }
    }

    void itemIconView(Image icon, ItemStats item, TMP_Text name, TMP_Text price)
    {
        if(item != null && icon != null)
        {
            icon.sprite = item.itemImage;

            name.text = item.itemName;
            price.text = item.price.ToString();
            
        }
    }
}


