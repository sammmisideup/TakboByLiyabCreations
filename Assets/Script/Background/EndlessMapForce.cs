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
    public float speedIncreaseInterval = 5f; 
    public float speedIncreaseAmount = 1f; 

    private float timeSinceLastIncrease = 0f; 

    void Awake()
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
        endlessMapRG.velocity = Vector2.left * endlessMapSpeed;

        timeSinceLastIncrease += Time.deltaTime;
        if (timeSinceLastIncrease >= speedIncreaseInterval)
        {
            endlessMapSpeed += speedIncreaseAmount;
            timeSinceLastIncrease = 0f;
        }

        if(EndlessPlayerController.instance.timeRemaining <= 0)
        {
            endlessMapSpeed = 0f;
        }

        // speedText.text = ((int)endlessMapSpeed).ToString();
        // scoreValue += 1f * Time.deltaTime;
    }
}
