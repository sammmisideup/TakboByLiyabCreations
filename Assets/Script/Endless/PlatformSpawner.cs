using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;

    [Header("Platform")]
    public List<GameObject> level1Prefabs; 
    public List<GameObject> level2Prefabs; 
    public List<GameObject> level3Prefabs; 
    public Transform spawnPoint;
    public Transform parentObject;
    public float followOffset = 5f;

    [Header("Trigger")]
    public Transform groundDetector;
    public float detectionRadius = 0.5f;
    public string groundTag = "Ground";

    [Header("Spawn")]
    public float spawnOffset1 = 2f;
    public float spawnOffset2 = 3f;
    public float spawnOffset3 = 4f;
    private int currentOffsetIndex = 0;
    private float[] spawnOffsets;

    private List<GameObject> activePlatforms = new List<GameObject>();
    private bool isGroundDetected;
    public bool canSpawn = true;

    public float platformLifetime = 10f;

    private List<GameObject> currentPrefabs;
    private float timeElapsed = 0f;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        //pagitan ng spawn
        spawnOffsets = new float[] { spawnOffset1, spawnOffset2, spawnOffset3 };

        currentPrefabs = level1Prefabs;
    }

    void Update()
    {
        //spawn offset detect
        MoveSpawnerWithOffset();
        isGroundDetected = IsGroundDetected();

        HandlePrefabLevelSwitch();

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
        //ground detect
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
        if (currentPrefabs.Count == 0)
        {
            Debug.LogWarning("No platform available");
            return;
        }
        canSpawn = false;

        int randomIndex = Random.Range(0, currentPrefabs.Count);
        GameObject newPlatform = Instantiate(currentPrefabs[randomIndex], spawnPoint.position, currentPrefabs[randomIndex].transform.rotation);
        newPlatform.transform.localScale = currentPrefabs[randomIndex].transform.localScale;

        if (parentObject != null)
        {
            newPlatform.transform.SetParent(parentObject);
        }

        activePlatforms.Add(newPlatform);

        Debug.Log("Platform spawned: " + newPlatform.name);

        Destroy(newPlatform, platformLifetime);

        StartCoroutine(EnableSpawningAfterOffset());
    }

    private IEnumerator EnableSpawningAfterOffset()
    {
        yield return new WaitForSeconds(spawnOffsets[currentOffsetIndex]);
        canSpawn = true;

        currentOffsetIndex = (currentOffsetIndex + 1) % spawnOffsets.Length;
    }

    private void HandlePrefabLevelSwitch()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 180f)
        {

            currentPrefabs = new List<GameObject>();
            currentPrefabs.AddRange(level1Prefabs);
            currentPrefabs.AddRange(level2Prefabs);
            currentPrefabs.AddRange(level3Prefabs);
        }
        else if (timeElapsed >= 60f)
        {

            currentPrefabs = level2Prefabs;
        }
        else
        {

            currentPrefabs = level1Prefabs;
        }
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
