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

    void Start()
    {
        countDownCount = countDownStart;
        countDownHolder.gameObject.SetActive(true);
        StartCoroutine(CountDownCo());
        Time.timeScale = 0;
    }

    private IEnumerator CountDownCo()
    {
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
            Time.timeScale = 1;
            countDownHolder.gameObject.SetActive(false);
        }
    }



}
