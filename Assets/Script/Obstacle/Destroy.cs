using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject prefabToSpawn;  
    public GameObject spawnLocation;  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            Destroy(gameObject);
           // Debug.Log($"{gameObject.name} nasera");

           
            if (prefabToSpawn != null && spawnLocation != null)
            {
               
                Instantiate(prefabToSpawn, spawnLocation.transform.position, spawnLocation.transform.rotation);
                Debug.Log($"{prefabToSpawn.name} has been spawned at {spawnLocation.name}.");
            }
            else
            {
                //Debug.LogWarning("inde lomabas");
            }
        }
    }
}
