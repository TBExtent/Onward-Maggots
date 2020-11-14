using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerZoneBehaviour : MonoBehaviour
{
    int type;

    private void Start() {
        if (gameObject.GetComponentInParent<GunTowerBehaviour>() != null) type = 1;
        if (gameObject.GetComponentInParent<RocketTowerBehaviour>() != null) type = 2;
        if (gameObject.GetComponentInParent<LaserTowerBehaviour>() != null) type = 3;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if      (type == 1) gameObject.GetComponentInParent<GunTowerBehaviour>().enableShooting();
        else if (type == 2) gameObject.GetComponentInParent<RocketTowerBehaviour>().enableShooting();
        else if (type == 3) gameObject.GetComponentInParent<LaserTowerBehaviour>().enableShooting();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (type == 1) gameObject.GetComponentInParent<GunTowerBehaviour>().disableShooting();
        else if (type == 2) gameObject.GetComponentInParent<RocketTowerBehaviour>().disableShooting();
        else if (type == 3) gameObject.GetComponentInParent<LaserTowerBehaviour>().disableShooting();
    }
}
