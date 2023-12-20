using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonSelect : MonoBehaviour
{
    public TMP_Text startTxt;
    public TMP_Text soundTxt;
    public TMP_Text exitTxt;

    private Color select;
    private Color defalut;

    private void Start()
    {
        defalut = Color.white;
        select = Color.yellow;

        startTxt.color = defalut;
        exitTxt.color = defalut;
    }
    public void OnButtonClick(int number)
    {
        if(number == 1)
        {
            startTxt.color = select;
            soundTxt.color = defalut;
            exitTxt.color = defalut;
            //SceneManager.LoadScene("");
        }
        else if(number == 2)
        {
            startTxt.color = defalut;
            soundTxt.color = select;
            exitTxt.color = defalut;
        }
        else if(number == 3)
        {
            startTxt.color = defalut;
            soundTxt.color = defalut;
            exitTxt.color = select;
            Application.Quit();
        }
    }

    public void GameStartButton()
    {
        SceneManager.LoadScene("VillageScene");
    }
}
