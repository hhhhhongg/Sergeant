using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMove : MonoBehaviour
{
    public TMP_Text startTxt;
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
            exitTxt.color = defalut;
            //SceneManager.LoadScene("");
        }
        else if(number == 2)
        {
            startTxt.color = defalut;
            exitTxt.color = select;
            Application.Quit();
        }
    }
}
