using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItems : MonoBehaviour
{
    public static DestroyItems instance;

    private GameObject Energy;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        Energy = this.gameObject;
    }

    void Update()
    {
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider col)
    {
        GameObject whatHit = col.gameObject;
        if(whatHit.tag == "Player")
        {
            if(Input.GetButtonDown("Grab"))
            {
                
                Destroy(Energy);
                Debug.Log("EnergyDestroy");
            }
            //  Destroy(Energy);
        }

    }
}
