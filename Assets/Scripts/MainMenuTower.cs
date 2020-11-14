using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTower : MonoBehaviour
{
    public GameObject Head;
    float angle;
    Vector3 mousePos;

    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        angle = AngleBetweenTwoPoints(mousePos, Head.transform.position);

        Head.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
