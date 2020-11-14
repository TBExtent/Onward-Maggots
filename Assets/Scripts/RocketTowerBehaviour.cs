using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTowerBehaviour : MonoBehaviour
{
    GameObject Target;
    public GameObject Head;
    public GameObject Body;
    public GameObject Rocket;
    float angle;
    bool shootingEnabled;
    bool canShoot = true;
    float health = 100f;

    // Update is called once per frame
    void Update() {
        if (Target != null) {
            angle = AngleBetweenTwoPoints(Target.transform.position, Head.transform.position);

            if (shootingEnabled) {
                Head.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            } else {
                Head.GetComponent<SpriteRenderer>().enabled = false;
            }

            if (shootingEnabled && canShoot) {
                canShoot = false;
                Head.GetComponent<SpriteRenderer>().enabled = false;
                Invoke("shootRocket", 1f);
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

    void shootRocket() {
        Head.GetComponent<SpriteRenderer>().enabled = true;
        Instantiate(Rocket, Head.transform.position, Quaternion.Euler(0f, 0f, angle));
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
        Rocket.GetComponent<RocketBehaviour>().setTarget(Target);
    }

    public void takeDamage(float amount) {
        health -= amount;
    }

}
