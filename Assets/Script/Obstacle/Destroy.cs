using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject prefabToSpawn;  
    public GameObject spawnLocation;  
    public string targetObjectNameInNextScene; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (prefabToSpawn != null && spawnLocation != null)
            {
                Instantiate(prefabToSpawn, spawnLocation.transform.position, spawnLocation.transform.rotation);
                Debug.Log($"{prefabToSpawn.name} has been spawned at {spawnLocation.name}.");
            }

            if (!string.IsNullOrEmpty(targetObjectNameInNextScene))
            {
                GameStateManager.Instance.MarkObjectVisible(targetObjectNameInNextScene);
                Debug.Log($"{targetObjectNameInNextScene} will be visible in the next scene.");
            }
        }
    }
}
