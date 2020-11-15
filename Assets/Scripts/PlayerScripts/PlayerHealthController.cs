using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public float playerHealth = 2500;
    [SerializeField] private Text healthText;

    private void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        healthText.text = playerHealth.ToString("0");
    }

    public void doDamage(int damage) 
    {
        playerHealth -= damage;

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
