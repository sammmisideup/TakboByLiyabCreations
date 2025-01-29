using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameovertween : MonoBehaviour
{
    [SerializeField]
    GameObject LevelFailed, backPanel, TryAgain, Back;

    void Start()
    {
       
        LeanTween.scale(LevelFailed, new Vector3(1.5f, 1.5f), 2f).setDelay(.5f).setEase(LeanTweenType.easeOutElastic).setOnComplete(LevelWin);
        LeanTween.scale(LevelFailed, new Vector3(1f, 1f, 1f), 2f).setDelay(1.7f).setEase(LeanTweenType.easeInOutCubic);
    }
    void LevelWin()
    {
        LeanTween.moveLocal(backPanel, new Vector3(0f, 0f, 0f), 0.7f).setDelay(.5f).setEase(LeanTweenType.easeOutCirc);
        LeanTween.scale(TryAgain, new Vector3(1f, 1f, 1f), 2f).setDelay(.7f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Back, new Vector3(1f, 1f, 1f), 2f).setDelay(.8f).setEase(LeanTweenType.easeOutElastic);
    }

}

