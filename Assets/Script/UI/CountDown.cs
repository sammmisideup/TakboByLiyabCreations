using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CountDown : MonoBehaviour
{
    public int countDownStart;
    public TextMeshProUGUI countDownText;
    public int countDownCount;
    public GameObject countDownHolder;
    public GameObject countDownMessage;
    public GameObject countDownNum;

    public GameObject player;
    public Animator animator;


    AudioManager audioManager;

    private void Awake()
    {

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        animator = player.GetComponent<Animator>();
        //animatorNanay = playerNanay.GetComponent<Animator>();
        countDownCount = countDownStart;
        countDownHolder.gameObject.SetActive(true);
        StartCoroutine(CountDownCo());
        //Time.timeScale = 0;
        ClassicMapForce.instance.enabled = false;
        animator.SetBool("idle", true);
        //animatorNanay.SetBool("idle", true);
    }

    private IEnumerator CountDownCo()
    {
        audioManager.StopSFX(audioManager.run);
        if(countDownCount>0)
        {
            countDownText.text = countDownCount.ToString();
            
        }else{
            countDownMessage.gameObject.SetActive(true);
            countDownNum.gameObject.SetActive(false);
        }
        

        yield return new WaitForSecondsRealtime(1f);
        countDownCount--;
        if(countDownCount>=0)
        {
            StartCoroutine(CountDownCo());
            
        }else{
            //Time.timeScale = 1;
            animator.SetBool("idle", false);
            //animatorNanay.SetBool("idle", false);
            ClassicMapForce.instance.enabled = true;
            countDownHolder.gameObject.SetActive(false);
            audioManager.Play2SFX(audioManager.run);
        }
    }



}
