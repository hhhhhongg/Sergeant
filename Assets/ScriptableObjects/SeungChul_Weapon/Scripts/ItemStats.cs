using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemStatData", menuName = "TopDownController/ItemData/Weapon", order = 2)]

public class ItemStats : ScriptableObject
{
    [Header("Item Info")]
    public int id;      // ��ȣ
    public string itemName;      // ������ �̸�
    public ItemType itemtype;       // ������ Ÿ��
    public ItemGrade itemgrade; // ������ ���
    public Sprite itemImage;         // ������ �̹���
    public bool isEquips;        // ���� ����

    [Header("Item Stats")]
    public int atk;     // ���ݷ�
    public int hp;       // ü��
    public int def;     // ����
    public int spd;     // �̵��ӵ�
    public string explan;        // ����
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
