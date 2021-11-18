using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPosition;
    private float startDelay = 1.0f, repeatRate = 2.0f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnPosition = new Vector3(25, 0, 0);

        InvokeRepeating("ObstacleSpawn", startDelay, repeatRate);

    }

    void ObstacleSpawn()
    {
        int randomIndex = Random.Range(0,obstaclePrefab.Length);
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab[randomIndex], spawnPosition, obstaclePrefab[randomIndex].transform.rotation);
        }
        
    }

}
