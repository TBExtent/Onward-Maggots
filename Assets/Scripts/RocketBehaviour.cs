﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public float speed = 1f;
    public GameObject Target;
    public Vector3 direction;

    private void Start() {
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

    public void setDirection(Vector3 dir) {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Minion")) {
            die();
        }
    }

}
