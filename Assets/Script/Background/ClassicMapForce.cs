using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClassicMapForce : MonoBehaviour
{
    public static ClassicMapForce instance;

    [SerializeField] private Rigidbody2D classicMapRG;

   // public TextMeshProUGUI speedText;

    public float classicMapSpeed = 40f;
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
        classicMapRG.velocity = Vector2.left * classicMapSpeed;
       // speedText.text = ((int)classicMapSpeed).ToString();
        //scoreValue += 1f *  Time.deltaTime;
    }
}
