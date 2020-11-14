using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTimeDelay = 0.01f;
    public GameObject hitEffect;
    void OnCollisionEnter2D(Collision2D collision)
    {
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effect, destroyTimeDelay);
        Destroy(gameObject);
    }
}
