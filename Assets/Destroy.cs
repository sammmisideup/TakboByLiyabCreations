using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("EndlessDestroy"))
        {
            Debug.Log("EndlessDestroy collision detected");
            Destroy(gameObject);  
        }
    }
}