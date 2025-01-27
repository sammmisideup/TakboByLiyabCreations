using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winningtween : MonoBehaviour
{
    [SerializeField]
    GameObject colorWheel, LevelComplete, backPanel, NextLevel, Back,
    star1, star2, star3;
    void Start()
    {
        LeanTween.rotateAround(colorWheel, Vector3.forward, -360, 10f).setLoopClamp();
        LeanTween.scale(LevelComplete, new Vector3(1.5f, 1.5f), 2f).setDelay(.5f).setEase(LeanTweenType.easeOutElastic).setOnComplete(LevelWin);
        LeanTween.scale(LevelComplete, new Vector3(1f, 1f, 1f), 2f).setDelay(1.7f).setEase(LeanTweenType.easeInOutCubic);
    }
    void LevelWin()
    {
        LeanTween.moveLocal(backPanel, new Vector3(0f, 0f, 0f), 0.7f).setDelay(.5f).setEase(LeanTweenType.easeOutCirc).setOnComplete(starAnim);
        LeanTween.scale(NextLevel, new Vector3(1f, 1f, 1f), 2f).setDelay(.7f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Back, new Vector3(1f, 1f, 1f), 2f).setDelay(.8f).setEase(LeanTweenType.easeOutElastic);
    }

    // Update is called once per frame
    void starAnim()
    {
        LeanTween.scale(star1, new Vector3(1.2f, 1.2f, 1.2f), 2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(star2, new Vector3(1.2f, 1.2f, 1.2f), 2f).setDelay(.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(star3, new Vector3(1.2f, 1.2f, 1.2f), 2f).setDelay(.2f).setEase(LeanTweenType.easeOutElastic);
    }
}

