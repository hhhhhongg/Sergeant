using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DungeonUIManager : MonoBehaviour
{
    public GameObject WinPanel;
    public Button WinPanel_Rty;
    public Button WinPanel_End;
    public Button LosePanel_Rty;
    public Button LosePanel_End;
    // Start is called before the first frame update

    private void Start()
    {
        HealthSystem.AddEventHandler(PlayerWin);
    }

    private void OnDestroy()
    {
        HealthSystem.RemoveEventHandler(PlayerWin);
    }
    public void PlayerWin()
    {
        ActiveWinPanel();
    }

    public void ReturnToVillage()
    {
        SceneManager.LoadScene("VillageScene");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void ActiveWinPanel()
    {
        WinPanel.SetActive(true);
    }



}
