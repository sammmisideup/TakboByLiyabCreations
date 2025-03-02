using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFast : MonoBehaviour
{

    public int slowFastSpeed;

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
            ClassicMapForce.instance.classicMapSpeed -= slowFastSpeed;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        GameObject Whathit = other.gameObject;
        if(other.gameObject.tag == "Player")
        {
            ClassicMapForce.instance.classicMapSpeed += slowFastSpeed;
        }
    }
}
