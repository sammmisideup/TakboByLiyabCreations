using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuuitween : MonoBehaviour

{
    [SerializeField]
    GameObject Logo, Prod, playButton, optionButton, exitButton;
    void Start()
    {

        LeanTween.scale(Logo, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Prod, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(playButton, new Vector3(1f, 1f, 1f), 2f).setDelay(.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(optionButton, new Vector3(1f, 1f, 1f), 2f).setDelay(.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(exitButton, new Vector3(1f, 1f, 1f), 2f).setDelay(.3f).setEase(LeanTweenType.easeOutElastic);
    }



}
