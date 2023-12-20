using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public static GoldManager instance;
    public TMP_Text gold;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetGold();
    }

    private void Update()
    {
        SetGold();
    }

    public void SetGold()
    {
        gold.text = DataManager.instance.userData.gold.ToString();
    }
}
