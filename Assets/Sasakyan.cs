using System.Collections;
using UnityEngine;

public class Sasakyan : MonoBehaviour
{
    public GameObject destructionEffect; 
    public float particleLifetime = 3f;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Stamina"))
        {
            SpawnEffect(other.transform.position);
            Destroy(other.gameObject);
        }
    }

    private void SpawnEffect(Vector3 position)
    {
        if (destructionEffect != null)
        {
            GameObject effect = Instantiate(destructionEffect, position, Quaternion.identity);
            Destroy(effect, particleLifetime); 
        }
    }
}
