using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMove : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Vector3> path;
    public float speed;
    public bool finished {
        get {
            return finished_;
        }
    }
    private bool finished_;
    private int pathStep;
    private Rigidbody2D rigidbody2d;

    void Awake()
    {
        pathStep = 1;
        finished_ = false;
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.gravityScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!finished) {
            Vector2 nextPos = new Vector3(path[pathStep].x, path[pathStep].y);
            Vector2 direction2D = nextPos - rigidbody2d.position;
            Vector2 move = direction2D.normalized * Time.deltaTime * speed;
            Vector2 dest = rigidbody2d.position + move;

            if (move.sqrMagnitude >= direction2D.sqrMagnitude) {
                dest = nextPos;
                pathStep++;
                if (pathStep == path.Count) {
                    finished_ = true;
                }
            }
            rigidbody2d.MovePosition(dest);
        }
    }
}
