using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarForce : MonoBehaviour
{
    // public static CarForce instance;

    [SerializeField] private Rigidbody carRG;

   // public TextMeshProUGUI speedText;

    public float carSpeed = 5f;

    // void Awake() {
    //     if (instance == null)
    //         instance = this;
    // }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        carRG.velocity = Vector2.left * carSpeed;
       // speedText.text = ((int)mapSpeed).ToString();
        //scoreValue += 1f *  Time.deltaTime;
    }
}
