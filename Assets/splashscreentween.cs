using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashscreentween : MonoBehaviour
    
{
    [SerializeField]
    GameObject startButton;
    void Start()
    {
        LeanTween.scale(startButton, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeOutElastic);
    }



}
