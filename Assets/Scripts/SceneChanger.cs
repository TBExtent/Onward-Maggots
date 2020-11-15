using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static void MainMenu()
    {
        PlayerPrefs.SetInt("Main Menu Panel", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
    public static void Credits()
    {
        PlayerPrefs.SetInt("Main Menu Panel", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
    public static void GameOver()
    {
        PlayerPrefs.SetInt("Main Menu Panel", 2);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
}
