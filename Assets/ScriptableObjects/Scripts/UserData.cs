using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "Data/UserData", order = 0)]
public class UserData : ScriptableObject
{
    public int atk;
    public int def;
    public int spd;
    public int hp;
    public int gold;
}
