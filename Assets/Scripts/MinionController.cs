using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    Vector3 movementInput;
    public float moveSpeed = 2f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.L)) movementInput.x = 1;
        else if (Input.GetKey(KeyCode.J)) movementInput.x = -1;
        else movementInput.x = 0;
        if (Input.GetKey(KeyCode.I)) movementInput.y = 1;
        else if (Input.GetKey(KeyCode.K)) movementInput.y = -1;
        else movementInput.y = 0;

        transform.position += movementInput * moveSpeed * Time.deltaTime;
    }
}
