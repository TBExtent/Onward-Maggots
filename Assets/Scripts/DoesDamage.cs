using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoesDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Minion")) {
            other.gameObject.GetComponent<MinionHealth>().doDamage(damage);
        }
        else if (other.gameObject.CompareTag("Player")) {
            //other.gameObject.GetComponent<PlayerHealthController>().doDamage(damage);
        }
    }

}
