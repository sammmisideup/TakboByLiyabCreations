using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject platformPrefab; 
    public Vector3 spawnOffset = new Vector3(0, 0, 10); 
    public float platformLength = 10f; 

    private Vector3 nextSpawnPosition;

    private void Start()
    {
        Debug.Log("GroundSpawner initialized. Spawning the first platform.");
        nextSpawnPosition = transform.position;
        SpawnPlatform();
    }

    private void SpawnPlatform()
    {
        if (platformPrefab == null)
        {
            Debug.LogError("PlatformPrefab is not assigned in the Inspector!");
            return;
        }

        Instantiate(platformPrefab, nextSpawnPosition, transform.rotation);
        Debug.Log("Platform spawned at position: " + nextSpawnPosition);

        nextSpawnPosition += new Vector3(0, 0, platformLength);
    }
}
