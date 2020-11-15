using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTimeDelay = 0.01f;
    public GameObject hitEffect;
    public float lifetime = .75f;

    public void Start() {
        Invoke("die", lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GunTower")) {
            collision.gameObject.GetComponent<GunTowerBehaviour>().takeDamage(10f);
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect, destroyTimeDelay);
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("LaserTower")) {
            collision.gameObject.GetComponent<LaserTowerBehaviour>().takeDamage(10f);
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect, destroyTimeDelay);
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("RocketTower")) {
            collision.gameObject.GetComponent<RocketTowerBehaviour>().takeDamage(10f);
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect, destroyTimeDelay);
            Destroy(gameObject);
        }
    }

    void die() {
        Destroy(gameObject);
    }

}
