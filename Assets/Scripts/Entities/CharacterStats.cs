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
    public int maxHealth;
    public int def;
    public float speed;
    [Range(10f, 100f)] public float dashSpeed;
    public AttackSO attackSO;
}
