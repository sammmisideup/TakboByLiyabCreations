using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTween : MonoBehaviour

{
    [SerializeField]
    GameObject Level1, Level2, Level3, Level4, Level5, Level6, Level7, Level8, Level9, Level10;
    void Start()
    {

        LeanTween.scale(Level1, new Vector3(1f, 1f, 1f), 2f).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Level2, new Vector3(1f, 1f, 1f), 2f).setDelay(1.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Level3, new Vector3(1f, 1f, 1f), 2f).setDelay(1.4f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Level4, new Vector3(1f, 1f, 1f), 2f).setDelay(1.6f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Level5, new Vector3(1f, 1f, 1f), 2f).setDelay(1.8f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Level6, new Vector3(1f, 1f, 1f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Level7, new Vector3(1f, 1f, 1f), 2f).setDelay(2.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Level8, new Vector3(1f, 1f, 1f), 2f).setDelay(2.4f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Level9, new Vector3(1f, 1f, 1f), 2f).setDelay(2.6f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Level10, new Vector3(1f, 1f, 1f), 2f).setDelay(2.8f).setEase(LeanTweenType.easeOutElastic);
    }



}