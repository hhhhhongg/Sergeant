using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemStatData", menuName = "TopDownController/ItemData/Weapon", order = 2)]

public class ItemStats : ScriptableObject
{
    [Header("Item Stats")]
    public int id;      // ��ȣ
    public bool equip;      // ���� ����

    public int atk;     // ���ݷ�
    public int hp;       // ü��
    public int def;     // ����
    public int spd;     // �̵��ӵ�
}
