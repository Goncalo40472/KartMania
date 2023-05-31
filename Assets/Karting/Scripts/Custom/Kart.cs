using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class Kart : MonoBehaviour
{

    public string racerName;
    float timer;
    public int totalCheckpoints;
    public float lastTime;
    GameObject lastCheckpoint;

    ArcadeKart arcadeKart;

    // Start is called before the first frame update
    void Start()
    {
        arcadeKart = GetComponent<ArcadeKart>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            if(other.gameObject == lastCheckpoint)
            {
                return;
            }

            lastCheckpoint = other.gameObject;
            lastTime = timer;
            totalCheckpoints++;
        }
    }
}
