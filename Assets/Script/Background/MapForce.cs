using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapForce : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mapRG;

    public static float mapSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        mapRG.velocity = Vector2.left * mapSpeed;
    }
}
