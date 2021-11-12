using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition;
    private float startDelay = 1.0f, repeatRate = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3(25, 0, 0);
        InvokeRepeating("ObstacleSpawn", startDelay, repeatRate);
    }

    void ObstacleSpawn()
    {
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
