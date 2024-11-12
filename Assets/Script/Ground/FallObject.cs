using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour
{
    public Rigidbody FallingObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision other)
    {
        GameObject Whathit = other.gameObject;
        if(other.gameObject.tag == "Player")
        {
            FallingObject.isKinematic = false;
        }
        
    }
}
