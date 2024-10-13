using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMovingObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        GameObject whatHit = col.gameObject;
        if(whatHit.CompareTag("MovingObstacle"))
        {
            Debug.Log("Destroy Moving Object");
            Destroy(col.gameObject);
        }

    }


}
