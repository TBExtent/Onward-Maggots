using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ShootingMinions()
    {
        SceneManager.LoadScene("ShootingMinions");
    }
}
