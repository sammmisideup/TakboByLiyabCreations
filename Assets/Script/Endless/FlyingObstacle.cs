using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObstacle : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 200f;

    void Update()
    {
        
        transform.position += Vector3.left * speed * Time.deltaTime;

       
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
