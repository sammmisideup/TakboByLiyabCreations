using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCollectible : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float scaleAmplitude = 0.5f; // How much the scale changes
    public float scaleSpeed = 0.1f; // Speed of scaling effect
    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        // Rotate around the Y-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
        
        // Scale up and down
        float scaleFactor = 1 + Mathf.Sin(Time.time * scaleSpeed) * scaleAmplitude;
        transform.localScale = startScale * scaleFactor;
    }
}
