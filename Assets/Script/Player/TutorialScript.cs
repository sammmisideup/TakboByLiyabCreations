using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject tutorialJump, tutorialGrab;
    public Animator tobyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        tobyAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "TutorialJump")
        {
            tobyAnimator.SetBool("idle", true);
            tutorialJump.SetActive(true);
            ClassicMapForce.instance.classicMapSpeed = 0;
        }
        
        if (col.gameObject.tag == "TutorialGrab")
        {
            tobyAnimator.SetBool("idle", true);
            tutorialGrab.SetActive(true);
            ClassicMapForce.instance.classicMapSpeed = 0;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "TutorialJump")
        {
            if (Input.GetButtonDown("Jump"))
            {
                tobyAnimator.SetBool("idle", false);
                tutorialJump.SetActive(false);
                ClassicMapForce.instance.classicMapSpeed = 40f;
            }
        }

        if (col.gameObject.tag == "TutorialGrab")
        {
            if (Input.GetKeyDown(KeyCode.G))  // Press G to collect item
            {
                tobyAnimator.SetBool("idle", false);
                tutorialGrab.SetActive(false);
                ClassicMapForce.instance.classicMapSpeed = 40f;
            }
        }
    }
}
