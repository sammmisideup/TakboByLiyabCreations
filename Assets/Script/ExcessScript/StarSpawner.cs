using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;          
    public Transform[] spawnPoints;        
    private int spawnIndex = 0;            

    public void SpawnStar()
    {
        if (starPrefab != null && spawnPoints.Length > 0)
        {

            GameObject spawnedStar = Instantiate(starPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
            StarDestroyListener listener = spawnedStar.AddComponent<StarDestroyListener>();
            listener.spawner = this;
            spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
        }
    }
}

public class StarDestroyListener : MonoBehaviour
{
    public StarSpawner spawner;  

   
    private void OnDestroy()
    {
        if (gameObject.CompareTag("Star"))
        {
           
            if (spawner != null)
            {
                spawner.SpawnStar();
            }
        }
    }
}
