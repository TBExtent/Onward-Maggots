using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionGoal : MonoBehaviour
{
    public int target;
    private int current;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 5f));
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Minion")) {
            other.gameObject.transform.parent.GetComponent<MinionSpawner>().MinionWasKilled();
            Destroy(other.gameObject);
            current++;

            if (current >= target) {
                Debug.Log("WOOOOOOO");
                SceneChanger.Credits();
            }
        }
    }
}
