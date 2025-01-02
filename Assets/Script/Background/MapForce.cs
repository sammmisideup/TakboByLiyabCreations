using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapForce : MonoBehaviour
{
    public static MapForce instance;

    [SerializeField] private Rigidbody2D mapRG;

   // public TextMeshProUGUI speedText;

    public float mapSpeed = 50f;
    // Start is called before the first frame update

    void awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        mapRG.velocity = Vector2.left * mapSpeed;
       // speedText.text = ((int)mapSpeed).ToString();
        //scoreValue += 1f *  Time.deltaTime;
    }
}
