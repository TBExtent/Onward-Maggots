using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTimeDelay = 0.01f;
    public GameObject hitEffect;

    public void Start() {
        Invoke("die", 2f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        if (collision.gameObject.CompareTag("GunTower")) {
            collision.gameObject.GetComponent<GunTowerBehaviour>().takeDamage(10f);
        } else if (collision.gameObject.CompareTag("LaserTower")) {
            collision.gameObject.GetComponent<LaserTowerBehaviour>().takeDamage(10f);
        } else if (collision.gameObject.CompareTag("RocketTower")) {
            collision.gameObject.GetComponent<RocketTowerBehaviour>().takeDamage(10f);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effect, destroyTimeDelay);
        Destroy(gameObject);
    }

    void die() {
        Destroy(gameObject);
    }

}
