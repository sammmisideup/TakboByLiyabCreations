using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cameraTransform;  
    public float parallaxEffectMultiplier = 0.5f; 

    private Vector3 lastCameraPosition;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        lastCameraPosition = cameraTransform.position;
    }

    void Update()
    {
        Vector3 cameraMovement = new Vector3(0, cameraTransform.position.y - lastCameraPosition.y, 0);
        Vector3 newPosition = transform.position + cameraMovement * parallaxEffectMultiplier;
        
        transform.position = newPosition;

        lastCameraPosition = cameraTransform.position;
    }
}
