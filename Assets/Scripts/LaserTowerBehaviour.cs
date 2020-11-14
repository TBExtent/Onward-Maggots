using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTowerBehaviour : MonoBehaviour
{
    public GameObject Player;
    public GameObject Head;
    public GameObject Laser;
    float angle;
    bool shootingEnabled;
    bool canShoot = true;

    private void Start() {
        Laser.GetComponent<LaserBehaviour>().setTarget(Player);
    }

    // Update is called once per frame
    void Update() {

        angle = AngleBetweenTwoPoints(Player.transform.position, Head.transform.position);

        if (shootingEnabled && canShoot) {
            canShoot = false;
            for (int i = 0; i < 5; i++) {
                Invoke("fireLaser", i * 0.02f);
            }
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void fireLaser() {
        Instantiate(Laser, Head.transform.position, Quaternion.Euler(0f, 0f, angle));
        canShoot = true;
    }

    public void enableShooting() {
        shootingEnabled = true;
    }

    public void disableShooting() {
        shootingEnabled = false;
    }
}
