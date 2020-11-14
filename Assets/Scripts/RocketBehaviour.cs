﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public float speed = 1f;
    public GameObject Target;
    Vector3 direction;

    private void Start() {
        direction = (Target.transform.position - transform.position);
        direction.z = 0;
        direction.Normalize();
        Invoke("die", .75f);
    }

    // Update is called once per frame
    void Update() {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void FixedUpdate() {

        speed *= 1.2f;
    }

    void die() {
        Destroy(gameObject);
    }

    public void setTarget(GameObject target) {
        Target = target;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Minion")) {
            die();
            // Damage target here
        }
    }

}