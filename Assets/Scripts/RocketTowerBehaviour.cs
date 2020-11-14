using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTowerBehaviour : MonoBehaviour
{
    public GameObject Player;
    public GameObject Head;
    public GameObject Rocket;
    float angle;

    private void Start() {
        Rocket.GetComponent<RocketBehaviour>().setTarget(Player);
    }

    // Update is called once per frame
    void Update() {
        angle = AngleBetweenTwoPoints(Player.transform.position, Head.transform.position);
        Head.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        if (Input.GetMouseButtonDown(2)) {
            Instantiate(Rocket, Head.transform.position, Quaternion.Euler(0f, 0f, angle));
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
