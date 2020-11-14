﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTowerBehaviour : MonoBehaviour
{
    GameObject Target;
    public GameObject Head;
    public GameObject Bullet;
    float angle;
    bool shootingEnabled;
    bool canShoot = true;

    // Update is called once per frame
    void Update() {
        if (Target != null) {
            angle = AngleBetweenTwoPoints(Target.transform.position, Head.transform.position);
            Head.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            if (shootingEnabled && canShoot) {
                canShoot = false;
                Invoke("shootBullet", 0.25f);
            }
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void shootBullet() {
        Instantiate(Bullet, Head.transform.position, Quaternion.Euler(0f, 0f, angle));
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
        Bullet.GetComponent<BulletBehaviour>().setTarget(Target);
    }

}
