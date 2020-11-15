using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public static Transform[] menus;
    public Transform startMenu;
    public AudioSource gameOverSound;
    public AudioSource menuMusic;

    private void Awake()
    {
        menus = new Transform[transform.childCount];
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i] = transform.GetChild(i);
        }

        if (PlayerPrefs.GetInt("Main Menu Panel") == 2)
        {
            gameOverSound.Play();
        }
        else
        {
            menuMusic.Play();
        }

        SwitchToMenu(PlayerPrefs.GetInt("Main Menu Panel"));
    }

    public static void SwitchToMenu(Transform currentMenu)
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

    public static void SwitchToMenu(int panelIndex)
    {
        SwitchToMenu(menus[panelIndex]);
    }


}
