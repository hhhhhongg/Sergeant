using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType;
    public int atk = DataManager.instance.userData.atk;
    public int def = DataManager.instance.userData.def;
    public float speed = DataManager.instance.userData.spd;
    public int maxHealth = DataManager.instance.userData.hp;
    [Range(10f, 100f)] public float dashSpeed;
    public AttackSO attackSO;
}
