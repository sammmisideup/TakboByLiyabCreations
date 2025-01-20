using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public List<GameObject> obstaclePrefabs; 
    public List<Transform> spawnPoints;    

    [Header("Spawn Timing")]
    public float spawnAtStart = 0f;         
    public float spawnTwoObjectsTime = 60f; 
    public float spawnThreeObjectsTime = 180f; 

    private bool hasSpawnedOnce = false;
    private bool hasSpawnedTwice = false;
    private bool hasSpawnedThrice = false;

    private void Update()
    {
        float elapsedTime = Time.time;

        if (!hasSpawnedOnce && elapsedTime >= spawnAtStart)
        {
            SpawnObstacles(1);
            hasSpawnedOnce = true;
        }

        if (!hasSpawnedTwice && elapsedTime >= spawnTwoObjectsTime)
        {
            SpawnObstacles(2); 
            hasSpawnedTwice = true;
        }

        if (!hasSpawnedThrice && elapsedTime >= spawnThreeObjectsTime)
        {
            SpawnObstacles(3); 
            hasSpawnedThrice = true;
        }
    }

    private void SpawnObstacles(int count)
    {

        List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);

        for (int i = 0; i < count; i++)
        {
            if (availableSpawnPoints.Count == 0)
            {
                Debug.LogWarning("Not enough spawn points available for the requested number of obstacles.");
                break;
            }

            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform selectedSpawnPoint = availableSpawnPoints[randomIndex];
            availableSpawnPoints.RemoveAt(randomIndex);


            int randomObstacleIndex = Random.Range(0, obstaclePrefabs.Count);
            GameObject obstaclePrefab = obstaclePrefabs[randomObstacleIndex];

            GameObject spawnedObstacle = Instantiate(obstaclePrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
            AttachToGround(spawnedObstacle);
        }
    }

    private void AttachToGround(GameObject obstacle)
    {
        StartCoroutine(MoveToGround(obstacle));
    }

    private System.Collections.IEnumerator MoveToGround(GameObject obstacle)
    {
        
        while (true)
        {
            if (obstacle == null) yield break;

            obstacle.transform.position += Vector3.down * Time.deltaTime;

            if (Physics.Raycast(obstacle.transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    obstacle.transform.position = new Vector3(obstacle.transform.position.x, hit.point.y, obstacle.transform.position.z);
                    yield break; 
                }
            }

            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint != null)
            {
                Gizmos.DrawWireSphere(spawnPoint.position, 0.5f);
            }
        }
    }
}
