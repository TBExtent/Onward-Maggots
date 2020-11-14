using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTowerController : MonoBehaviour
{
    public static Transform[] towers;
    private void Awake()
    {
        towers = new Transform[transform.childCount];
        for (int i = 0; i < towers.Length; i++)
        {
            towers[i] = transform.GetChild(i);
        }

        SwitchTower();
    }

    public void SwitchTower()
    {
        int rand_int = Random.Range(0, towers.Length);
        
        towers[rand_int].gameObject.SetActive(true);

        for (int i = 0; i < towers.Length; i++)
        {
            if (i != rand_int)
            {
                towers[i].gameObject.SetActive(false);
            }
        }
    }
}
