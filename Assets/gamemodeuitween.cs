using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemodeuitween : MonoBehaviour

{
    [SerializeField]
    GameObject Logo, Prod, StoryMode, EndlessMode, backButton, settingsButton;
    void Start()
    {

        LeanTween.scale(Logo, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Prod, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(StoryMode, new Vector3(1f, 1f, 1f), 2f).setDelay(.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(EndlessMode, new Vector3(1f, 1f, 1f), 2f).setDelay(.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(backButton, new Vector3(1f, 1f, 1f), 2f).setDelay(.3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(settingsButton, new Vector3(1f, 1f, 1f), 2f).setDelay(.3f).setEase(LeanTweenType.easeOutElastic);
    }



}