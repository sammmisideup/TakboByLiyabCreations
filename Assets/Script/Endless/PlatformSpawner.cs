using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Platform Settings")]
    public List<GameObject> platformPrefabs; 
    public Transform spawnPoint;            
    public Transform parentObject;          
    public float followOffset = 5f;         

    [Header("Trigger Settings")]
    public Transform groundDetector;      
    public float detectionRadius = 0.5f;   
    public string groundTag = "Ground";    

    [Header("Spawn Settings")]
    public float spawnOffset = 2f;        

    private List<GameObject> activePlatforms = new List<GameObject>();
    private bool isGroundDetected;
    private bool canSpawn = true;         

    void Update()
    {
        MoveSpawnerWithOffset();
        isGroundDetected = IsGroundDetected();

        if (!isGroundDetected && canSpawn)
        {
            SpawnPlatform();
        }
    }

    private void MoveSpawnerWithOffset()
    {
        transform.position += new Vector3(followOffset * Time.deltaTime, 0, 0);
    }

    private bool IsGroundDetected()
    {
        Collider[] colliders = Physics.OverlapSphere(groundDetector.position, detectionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(groundTag))
            {
                return true;
            }
        }
        return false;
    }

    private void SpawnPlatform()
    {
        if (platformPrefabs.Count == 0)
        {
            Debug.LogWarning("No platform prefabs available for spawning!");
            return;
        }
        canSpawn = false;

        int randomIndex = Random.Range(0, platformPrefabs.Count);
        GameObject newPlatform = Instantiate(platformPrefabs[randomIndex], spawnPoint.position, platformPrefabs[randomIndex].transform.rotation);
        newPlatform.transform.localScale = platformPrefabs[randomIndex].transform.localScale;

        if (parentObject != null)
        {
            newPlatform.transform.SetParent(parentObject);
        }

        activePlatforms.Add(newPlatform);

        Debug.Log("Platform spawned: " + newPlatform.name);

        StartCoroutine(EnableSpawningAfterOffset());
    }

    private IEnumerator EnableSpawningAfterOffset()
    {
        yield return new WaitForSeconds(spawnOffset);
        canSpawn = true;
    }

    private void OnDrawGizmos()
    {

        if (groundDetector != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundDetector.position, detectionRadius);
        }
    }
}
