using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public static Transform[] menus;
    public Transform startMenu;

    private void Awake()
    {
        menus = new Transform[transform.childCount];
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i] = transform.GetChild(i);
        }

        SwitchToMenu(startMenu);
    }

    public void SwitchToMenu(Transform currentMenu)
    {
        currentMenu.gameObject.SetActive(true);
        for (int i = 0; i < menus.Length; i++)
        {
            if(menus[i] != currentMenu)
            {
                menus[i].gameObject.SetActive(false);
            }
        }
    }
}
