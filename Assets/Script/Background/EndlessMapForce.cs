using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndlessMapForce : MonoBehaviour
{
    public static EndlessMapForce instance;

    [SerializeField] private Rigidbody2D endlessMapRG;

   // public TextMeshProUGUI speedText;

    public float endlessMapSpeed = 40f;
    // Start is called before the first frame update

    void Awake()
    {
        if(instance == null)
        instance = this;
    }

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        endlessMapRG.velocity = Vector2.left * endlessMapSpeed;
       // speedText.text = ((int)endlessMapSpeed).ToString();
        //scoreValue += 1f *  Time.deltaTime;
    }
}
