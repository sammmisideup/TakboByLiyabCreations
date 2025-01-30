using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject tutorialJump, tutorialGrab;
    public Animator tobyAnimator;
    public bool isJump;
    public bool isGrab;
    // Start is called before the first frame update
    void Start()
    {
        tobyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isJump)
            {
                tobyAnimator.SetBool("idle", false);
                tutorialJump.SetActive(false);
                ClassicMapForce.instance.classicMapSpeed = 40f;
                isJump = false;
            }

        if (Input.GetKeyDown(KeyCode.G) && isGrab)  // Press G to collect item
            {
                tobyAnimator.SetBool("idle", false);
                tutorialGrab.SetActive(false);
                ClassicMapForce.instance.classicMapSpeed = 40f;
                isGrab = false;
            }
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "TutorialJump")
        {
            tobyAnimator.SetBool("idle", true);
            tutorialJump.SetActive(true);
            ClassicMapForce.instance.classicMapSpeed = 0;
            isJump = true;
        }
        
        if (col.gameObject.tag == "TutorialGrab")
        {
            tobyAnimator.SetBool("idle", true);
            tutorialGrab.SetActive(true);
            ClassicMapForce.instance.classicMapSpeed = 0;
            isGrab = true;
        }
    }

    // private void OnTriggerStay(Collider col)
    // {
    //     if (col.gameObject.tag == "TutorialJump")
    //     {
            
    //     }

    //     if (col.gameObject.tag == "TutorialGrab")
    //     {
            
    //     }
    // }
}
