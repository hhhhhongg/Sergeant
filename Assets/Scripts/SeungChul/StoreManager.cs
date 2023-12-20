using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public InventoryData inventoryData;

    public int selectItemIndex = 0;
    
    public TMP_Text userMoney;
    int buyMoney = 0;

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


    public GameObject _Omoney;
    public GameObject _Xmoney;

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

        selectItemIndex = itemIndex;
    }

    public void BuyItem()
    {
        int userM = int.Parse(userMoney.text);

        // 선택한 아이템 가격
        buyMoney = int.Parse(infoItem_price.text);
        // 아이템 계산
        if(userM < buyMoney)
        {
            print("소지금이 부족합니다!");
            _Xmoney.SetActive(true);
        }
        else if(userM >= buyMoney)
        {
            userMoney.text = (userM - buyMoney).ToString();
            Additem(itemStats[selectItemIndex]);
            _Omoney.SetActive(false);
            print("구매 완료");
        }
        // 데이터 바꾸기
        DataManager.instance.userData.gold = int.Parse(userMoney.text);

    }

    // 인벤토리 추가
    void Additem(ItemStats item)
    {
        // inventoryData에 데이터가 있는 지 확인
        if(inventoryData != null)
        {
            //if(inventoryData.myItems == null)
            //{
            //    // 배열이 존재하지 않으면 새로운 배열을 생성
            //    inventoryData.myItems =
            //    print("dd");
            //}
            //else
            //{
            //    // myItems에 배열이 존재한다면 기본 배열에 아이템을 추가
            //    List<ItemStats> itemList = new List<ItemStats>(inventoryData.myItems);
            //    itemList.Add(item);
            //    //inventoryData.myItems = itemList.ToArray();
            //    print("aa");
                DataManager.instance.inventoryData.myItems.Add(item);
            //}

        }
        else
        {   
            print("멸망");
        }
    }
}


