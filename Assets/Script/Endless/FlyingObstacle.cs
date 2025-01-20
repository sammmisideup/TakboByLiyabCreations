using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObstacle : MonoBehaviour
{
   
    public float speed = 5f;

    private Vector3 moveDirection;

    void Start()
    {

        moveDirection = new Vector3(-1, -1, 0).normalized; 
    }

    void Update()
    {
        
        transform.position += moveDirection * speed * Time.deltaTime;

       
        if (transform.position.x < -10 || transform.position.y < -10) 
        {
            Destroy(gameObject);
        }
    }
}
