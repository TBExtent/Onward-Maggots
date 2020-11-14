using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Main Menu Panel", 0);
        PlayerPrefs.Save();
        SceneChanger.MainMenu();
    }
}
