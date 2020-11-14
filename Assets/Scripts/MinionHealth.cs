using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionHealth : MonoBehaviour
{

    public int maxHealth;
    private int currentHealth;

    public void Awake() {
        currentHealth = maxHealth;
    }

    public void doDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {

            Destroy(gameObject);
        }
    }

}
