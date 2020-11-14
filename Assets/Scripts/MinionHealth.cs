using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionHealth : MonoBehaviour
{

    public int maxHealth;
    private int currentHealth;
    private bool isDead = false;

    public void Awake() {
        currentHealth = maxHealth;
    }

    public void doDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0 && !isDead) {

            Destroy(gameObject);
            gameObject.transform.parent.GetComponent<MinionSpawner>().MinionWasKilled();
            isDead = true;
        }
    }

}
