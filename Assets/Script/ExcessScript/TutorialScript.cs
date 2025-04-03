using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject tutorialJump, tutorialGrab, tutorialDown, downCollider;
    public Animator tobyAnimator;
    public bool isJump;
    public bool isGrab;
    public bool isDown;
    public Rigidbody rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        tobyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isJump || Input.GetKeyDown(KeyCode.UpArrow) && isJump)
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

        if(Input.GetKeyDown(KeyCode.S) && isDown || Input.GetKeyDown(KeyCode.DownArrow) && isDown)
        {
            tobyAnimator.SetBool("idle", false);
            tutorialDown.SetActive(false);
            ClassicMapForce.instance.classicMapSpeed = 40f;
            rbPlayer.isKinematic = false;
            isDown= false;
            downCollider.SetActive(false);
        }
        
    }

    public void JumpButton()
    {
        if (isJump)
        {
            tobyAnimator.SetBool("idle", false);
            tutorialJump.SetActive(false);
            ClassicMapForce.instance.classicMapSpeed = 40f;
            isJump = false;
            
        }
    }

    public void GrabButton()
    {
        if (isGrab)  // Press G to collect item
        {
            tobyAnimator.SetBool("idle", false);
            tutorialGrab.SetActive(false);
            ClassicMapForce.instance.classicMapSpeed = 40f;
            isGrab = false;
        }
    }

    public void DownButton()
    {
        if (isDown) 
        {
            tobyAnimator.SetBool("idle", false);
            tutorialDown.SetActive(false);
            ClassicMapForce.instance.classicMapSpeed = 40f;
            rbPlayer.isKinematic = false;
            isDown= false;
            downCollider.SetActive(false);
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

        if (col.gameObject.tag == "TutorialDown")
        {
            tobyAnimator.SetBool("idle", true);
            tutorialDown.SetActive(true);
            ClassicMapForce.instance.classicMapSpeed = 0;
            rbPlayer.isKinematic = true;
            isDown= true;
            Debug.Log("Go Down");
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
