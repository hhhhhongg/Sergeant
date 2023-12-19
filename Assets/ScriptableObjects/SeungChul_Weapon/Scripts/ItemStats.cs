using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemStatData", menuName = "TopDownController/ItemData/Weapon", order = 2)]

public class ItemStats : ScriptableObject
{
    [Header("Item Info")]
    public int id;      // 번호
    public string itemName;      // 아이템 이름
    public ItemType itemtype;       // 아이템 타입
    public ItemGrade itemgrade; // 아이템 등급
    public Sprite itemImage;         // 아이템 이미지
    public bool isEquips;        // 장착 여부

    [Header("Item Stats")]
    public int atk;     // 공격력
    public int hp;       // 체력
    public int def;     // 방어력
    public int spd;     // 이동속도
    public string explan;        // 설명
}

public enum ItemType
{
    None,
    Weapon,
    Hat,
    Armor,
    Shoes
}

public enum ItemGrade
{
    Normal,
    Rare,
    Unique
}
