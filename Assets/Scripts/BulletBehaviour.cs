using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 50f;
    public Vector3 direction;

    private void Start() {
        Invoke("die", .75f);
    }

    // Update is called once per frame
    void Update() {
        transform.position += direction * speed * Time.deltaTime * transform.localScale.x;
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
