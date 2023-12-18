using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemStatData", menuName = "TopDownController/ItemData/Weapon", order = 2)]

public class ItemStats : ScriptableObject
{
    [Header("Item Stats")]
    public int id;      // 번호
    public bool equip;      // 장착 유무

    public int atk;     // 공격력
    public int hp;       // 체력
    public int def;     // 방어력
    public int spd;     // 이동속도
}
