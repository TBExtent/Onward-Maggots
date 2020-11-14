using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTowerBehaviour : MonoBehaviour
{
    GameObject Target;
    public GameObject Head;
    public GameObject Body;
    public GameObject Laser;
    float angle;
    bool shootingEnabled;
    bool canShoot = true;
    float health = 100f;

    // Update is called once per frame
    void Update() {
        if (shootingEnabled) {
            Head.transform.Rotate(0, 0, 5f);
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

        Head.GetComponent<SpriteRenderer>().color = new Color(1, health / 100, health / 100);
        Body.GetComponent<SpriteRenderer>().color = new Color(1, health / 100, health / 100);

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
        Vector3 direction = (Target.transform.position - Head.transform.position);
        direction.z = 0;
        direction.Normalize();
        Laser.GetComponent<LaserBehaviour>().setDirection(direction);
        Laser.GetComponent<LaserBehaviour>().speed = 70f * transform.localScale.x;
        Laser.transform.localScale = transform.localScale;
    }

    public void takeDamage(float amount) {
        health -= amount;
    }

}
