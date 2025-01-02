using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour
{
    public Rigidbody FallingObject;
    public float fallSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        GameObject Whathit = other.gameObject;
        if(other.gameObject.tag == "Player")
        {
            FallingObject.isKinematic = false;
            FallingObject.velocity = Vector2.down * fallSpeed;
        }
    }
}
