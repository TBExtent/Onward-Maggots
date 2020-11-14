using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTowerBehaviour : MonoBehaviour
{
    public GameObject Target;
    public GameObject Head;
    public GameObject Laser;
    float angle;
    bool shootingEnabled;
    bool canShoot = true;
    float health = 100f;

    // Update is called once per frame
    void Update() {
        if (!shootingEnabled) {
            Head.GetComponent<SpriteRenderer>().color = new Color(.4f, .4f, .4f);
        } else {
            Head.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f);
        }

        if (Target != null) {
            angle = AngleBetweenTwoPoints(Target.transform.position, Head.transform.position);

            if (shootingEnabled && canShoot) {
                canShoot = false;
                for (int i = 0; i < 5; i++) {
                    Invoke("fireLaser", i * 0.02f);
                }
            }
        }

        if (health <= 0f) {
            Destroy(gameObject);
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

    public void setTarget(GameObject target) {
        Target = target;
        Laser.GetComponent<LaserBehaviour>().setTarget(Target);
    }

    public void takeDamage(float amount) {
        health -= amount;
    }

}
