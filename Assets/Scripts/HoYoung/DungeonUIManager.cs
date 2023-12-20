using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonUIManager : MonoBehaviour
{
    public GameObject WinPanel;
    // Start is called before the first frame update

    private void Start()
    {
        Boss.AddEventHandler(PlayerWin);
    }
    public void PlayerWin()
    {
        ActiveWinPanel();
    }

    private void ActiveWinPanel()
    {
        WinPanel.SetActive(true);
    }



}
