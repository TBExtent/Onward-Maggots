using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionDeathNoiseController : MonoBehaviour
{
    public GameObject[] Clips;

    public void minionHasDied() {
        int i = Random.Range(0, Clips.Length);
        Clips[i].GetComponent<AudioSource>().Play();
    }
}
