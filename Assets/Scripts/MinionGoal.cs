using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionGoal : MonoBehaviour
{
    public int target;
    private int current;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        text = GameObject.Find("Canvas").GetComponentInChildren<Text>();
        text.text = "Minions teleported: " + current + "/" + target;
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
            text.text = "Minions teleported: " + current + "/" + target;

            if (current >= target) {
                Debug.Log("WOOOOOOO");
                SceneChanger.Credits();
            }
        }
    }
}
