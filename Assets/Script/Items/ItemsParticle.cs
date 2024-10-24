using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsParticle : MonoBehaviour
{

    [SerializeField] private ParticleSystem ItemsSmokeParticle = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider col)
    {
        GameObject whatHit = col.gameObject;
        if(col.gameObject.tag == "Player")
        {   
            if(Input.GetButtonDown("Grab"))
            {
                ItemsSmokeParticle.Play();
            }
        }
    }

}
