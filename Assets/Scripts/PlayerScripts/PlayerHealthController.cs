using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public float playerHealth = 2500;
    [SerializeField] private Text healthText;
    private bool doAlarm;
    public float alarmThresh = 500;

    private void Start()
    {
        doAlarm = true;
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        healthText.text = playerHealth.ToString("0");
    }

    public void doDamage(int damage) 
    {
        playerHealth -= damage;

        if (doAlarm && playerHealth <= alarmThresh) {
            doAlarm = false;

            //Play alarm sound
        }

        if (playerHealth <= 0) {
            playerHealth = 0;
            UpdateHealth();
            SceneChanger.GameOver();
            //Destroy(gameObject);
        } 
        else 
        {
            UpdateHealth();
        }

    }
}
