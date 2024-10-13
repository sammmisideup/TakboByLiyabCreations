using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapForce : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mapRG;

    public float mapSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        mapRG.velocity = Vector2.left * mapSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
