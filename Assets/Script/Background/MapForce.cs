using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapForce : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mapRG;

   // public TextMeshProUGUI speedText;

    public static float mapSpeed = 5f;
    // Start is called before the first frame update
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
