using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    public float speed = 70f;
    public GameObject Target;
    public Vector3 direction;

    private void Start() {
        Invoke("die", .75f);
    }

    // Update is called once per frame
    void Update() {
        transform.position += direction * speed * Time.deltaTime;
    }

    void die() {
        Destroy(gameObject);
    }

    public void setDirection(Vector3 dir) {
        direction = dir;
    }

    /*private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Minion")) {
            die();
            // Damage target here
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Minion")) {
            die();
            // Damage target here
        }
    }
}
