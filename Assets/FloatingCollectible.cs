using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCollectible : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float scaleAmplitude = 2f; 
    public float scaleSpeed = 10f; 
    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
        
        
        float scaleFactor = 1 + Mathf.Sin(Time.time * scaleSpeed) * scaleAmplitude;
        transform.localScale = startScale * scaleFactor;
    }
}
