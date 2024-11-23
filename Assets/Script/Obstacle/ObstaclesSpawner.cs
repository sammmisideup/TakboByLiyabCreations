using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{

    [SerializeField] public GameObject[] obstaclePrefabs;
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

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody obstacleRB = spawnedObstacle.GetComponent<Rigidbody>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }





}
