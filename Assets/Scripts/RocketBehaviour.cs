using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public float accel = 10f;
    public GameObject Target;
    public Vector3 direction;
    public float lifetime = .75f;
    public GameObject hitEffect;
    public float destroyTimeDelay = 0.05f;
    private Rigidbody2D rigidbody2D;

    private void Start() {
        Invoke("die", lifetime);
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if (Target != null) {
            direction = (Target.transform.position - transform.position);
            direction.z = 0;
            //direction.Normalize();
            /*if (rigidbody2D.velocity.sqrMagnitude >= 0.1) {
                direction = Vector2.Reflect(rigidbody2D.velocity, Vector2.Perpendicular(direction));
                direction.z = 0;
            }*/
            direction.Normalize();
        }
        rigidbody2D.AddForce(direction * accel * (1 + Vector2.Angle(Vector2.right, rigidbody2D.velocity) / 180));
        rigidbody2D.SetRotation(Vector2.SignedAngle(Vector2.right, rigidbody2D.velocity));
        //transform.position += direction * speed * Time.deltaTime;
    }

    //private void FixedUpdate() {

        //speed *= 1.2f;
    //}

    void die() {
        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effect, destroyTimeDelay);
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
