using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMove : MonoBehaviour
{
    public Button buttonMove;
    public TMP_Text btnText;

    public void OnButtonClick()
    {
        switch (buttonMove.name)
        {
            case "StartBtn":
                MoveButtonPosition(new Vector3(0f, -100f, 0f));
                btnText.color = Color.yellow;
                //SceneManager.LoadScene("");
                break;
            case "ExitBtn":
                MoveButtonPosition(new Vector3(0f, -300f, 0f));
                btnText.color = Color.yellow;
                Application.Quit();
                break;
            default:
                print("Ω««‡X");
                break;
        }
    }

    void MoveButtonPosition(Vector3 newPosition)
    {
        RectTransform buttonTransform = buttonMove.GetComponent<RectTransform>();
        buttonTransform.localPosition = newPosition;
    }

    public void OnMouseEnterButton()
    {
        btnText.color = Color.yellow;
    }

    public void OnMouseExitButton()
    {
        btnText.color = Color.white;
    }
}
