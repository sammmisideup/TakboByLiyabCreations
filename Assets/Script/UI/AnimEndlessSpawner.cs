using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEndlessSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] obstaclePrefabs;
    //[SerializeField] public GameObject carPrefabs;
    public Transform spawnPoints;
    public GameObject parentObject;

    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 1f;

    private float timeUntilObstacleSpawn;

    // Update is called once per frame
    private void Update()
    {
        SpawnLoop();
        
    }

    private  void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime) 
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }
    

    private void Spawn() 
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, spawnPoints.position, Quaternion.identity);
        spawnedObstacle.transform.SetParent(parentObject.transform);
        Destroy(spawnedObstacle, 15f);

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
        
    }
    
}
