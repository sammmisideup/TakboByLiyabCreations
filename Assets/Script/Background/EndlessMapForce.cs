using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndlessMapForce : MonoBehaviour
{
    public static EndlessMapForce instance;

    [SerializeField] private Rigidbody2D endlessMapRG;

    public float baseSpeed = 40f;
    public float speedIncreaseInterval = 5f; 
    public float speedIncreaseAmount = 1f; 

    private float elapsedTime = 0f; 

    
    public float endlessMapSpeed; 

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        endlessMapSpeed = baseSpeed; 
    }

    void Update()
    {
        elapsedTime += Time.deltaTime; 

        
        endlessMapSpeed = baseSpeed + (Mathf.Floor(elapsedTime / speedIncreaseInterval) * speedIncreaseAmount);

       
        endlessMapRG.velocity = Vector2.left * endlessMapSpeed;

        
        if (EndlessPlayerController.instance.timeRemaining <= 0)
        {
            endlessMapRG.velocity = Vector2.zero;
            endlessMapSpeed = 0f; 
        }
    }
}
