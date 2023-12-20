using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    //public UnityEvent PlayerWin;

    public delegate void PlayerWin();

    public static event PlayerWin ChangeCameraPosition;

    private static List<PlayerWin> PlayerWinHandlers = new List<PlayerWin>();


    public static void AddEventHandler(PlayerWin handler)
    {
        PlayerWinHandlers.Add(handler);
    }

    // 이벤트 핸들러 해제
    public static void RemoveEventHandler(PlayerWin handler)
    {
        PlayerWinHandlers.Remove(handler);
    }
    // Start is called before the first frame update
    private void OnDestroy()
    {
        Debug.Log("Boss is dead!!!!!");
        foreach (var handler in PlayerWinHandlers)
        {
            handler();
        }
    }
}
