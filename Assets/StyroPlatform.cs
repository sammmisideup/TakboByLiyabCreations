using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyroPlatform : MonoBehaviour
{
    public float moveSpeed = 1f; 
    public float delayBeforeMoving = 2f; 

    private Transform grandParentTransform;
    private bool shouldMove = false;

    void Start()
    {
        
        if (transform.parent != null && transform.parent.parent != null)
        {
            grandParentTransform = transform.parent.parent;
            Invoke(nameof(StartMoving), delayBeforeMoving);
        }
        else
        {
            Debug.LogError("StyroPlatform: Grandparent transform is missing!", this);
        }
    }

    void StartMoving()
    {
        shouldMove = true;
    }

    void Update()
    {
        if (shouldMove && grandParentTransform != null)
        {
            grandParentTransform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
    }
}
