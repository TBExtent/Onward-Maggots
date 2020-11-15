using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public float accel = 10f;
    public GameObject Target;
    public Vector3 direction;
    private Rigidbody2D rigidbody2D;

    private void Start() {
        Invoke("die", .75f);
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if (Target != null) {
            direction = (Target.transform.position - transform.position);
            direction.z = 0;
            direction.Normalize();
        }
        rigidbody2D.AddForce(direction * accel);
        rigidbody2D.SetRotation(Vector2.SignedAngle(Vector2.right, rigidbody2D.velocity));
        //transform.position += direction * speed * Time.deltaTime;
    }

    //private void FixedUpdate() {

        //speed *= 1.2f;
    //}

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
