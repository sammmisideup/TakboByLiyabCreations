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
    public Animator tobyAnimator;

    void Start()
    {
        tobyAnimator = player.GetComponent<Animator>();
        countDownCount = countDownStart;
        countDownHolder.gameObject.SetActive(true);
        StartCoroutine(CountDownCo());
        //Time.timeScale = 0;
        ClassicMapForce.instance.enabled = false;
        tobyAnimator.SetBool("idle", true);
    }

    private IEnumerator CountDownCo()
    {
    
        //tobyAnimator.SetTrigger("runn");
        if(countDownCount>0)
        {
            countDownText.text = countDownCount.ToString();
            //tobyAnimator.SetTrigger("runn");
        }else{
            countDownMessage.gameObject.SetActive(true);
            countDownNum.gameObject.SetActive(false);
        }
        

        yield return new WaitForSecondsRealtime(1f);
        countDownCount--;
        if(countDownCount>=0)
        {
            StartCoroutine(CountDownCo());
            //tobyAnimator.SetTrigger("runn");
        }else{
            //Time.timeScale = 1;
            tobyAnimator.SetBool("idle", false);
            ClassicMapForce.instance.enabled = true;
            countDownHolder.gameObject.SetActive(false);
        }
    }



}
