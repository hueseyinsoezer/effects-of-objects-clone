using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3(25, 0, 0);
        InvokeRepeating("ObstacleSpawn", 1.0f, 2.0f);
    }

    void ObstacleSpawn()
    {
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
