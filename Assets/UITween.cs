using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITween : MonoBehaviour
{
    [SerializeField] GameObject backPanel, NextLevel, Back,
    
    Star1, Star2, Star3, levelSuccess;
    void Start()
    {
        LeanTween.scale(Star1, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Star2, new Vector3(1f, 1f, 1f), 2f).setDelay(.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Star3, new Vector3(1f, 1f, 1f), 2f).setDelay(.2f).setEase(LeanTweenType.easeOutElastic);
    }

    // Update is called once frame
    void Update()
    {
        
    }
}
