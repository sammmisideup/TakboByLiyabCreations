using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleParticle : MonoBehaviour
{

    [SerializeField] private ParticleSystem smokeParticle = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        GameObject whatHit = col.gameObject;
        if(col.gameObject.tag == "Player")
        {
            smokeParticle.Play();
        }
    }

}
