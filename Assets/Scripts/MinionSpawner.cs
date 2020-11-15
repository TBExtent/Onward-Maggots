using System;
using System.Collections.Generic;
using UnityEngine;


public class MinionSpawner : MonoBehaviour
{
    public List<GameObject> minions;
    public List<int> minionProportions;
    public double spawnProb;
    public int maxSpawnedMinions;
    public int maxActiveMinions;
    public GameObject MinionNoisePlayer;

    private int sum = -1;
    private LineRenderer lr = null;
    private int spawnedMinions = 0;
    private int activeMinions = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lr == null) {
            lr = GetComponent<LineRenderer>();
        }

        if (sum == -1) {
            for (int i = 0; i < minions.Count; i++) {
                sum += minionProportions[i];
            }
        }

        if (maxSpawnedMinions == -1 || spawnedMinions < maxSpawnedMinions) {
            if (maxActiveMinions == -1 || activeMinions < maxActiveMinions) {
                if (UnityEngine.Random.value < spawnProb || spawnProb == 1) {
                    int minionID = UnityEngine.Random.Range(0, sum);

                    for (int i = 0; i < minions.Count; i++) {
                        if (minionProportions[i] >= minionID) {
                            Vector3[] path = new Vector3[lr.positionCount];
                            lr.GetPositions(path);

                            Vector3 start = path[0];
                            start.z = 0;
                            GameObject minion = Instantiate(minions[i], start, Quaternion.identity, transform);

                            minion.GetComponent<MinionMove>().path = new List<Vector3>(path);
                        }
                        else minionID -= minionProportions[i];

                        spawnedMinions++;
                        activeMinions++;
                    }
                }
            }
        }
    }

    public void MinionWasKilled() {
        activeMinions--;
        MinionNoisePlayer.GetComponent<MinionDeathNoiseController>().minionHasDied();
    }
}
