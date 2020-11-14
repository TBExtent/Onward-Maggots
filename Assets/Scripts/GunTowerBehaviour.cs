using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTowerBehaviour : MonoBehaviour
{
    public GameObject Player;
    public GameObject Head;
    public GameObject Bullet;
    float angle;

    private void Start() {
        Bullet.GetComponent<BulletBehaviour>().setTarget(Player);
    }

    // Update is called once per frame
    void Update()
    {
        angle = AngleBetweenTwoPoints(Player.transform.position, Head.transform.position);
        Head.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(Bullet, Head.transform.position, Quaternion.Euler(0f, 0f, angle));
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
