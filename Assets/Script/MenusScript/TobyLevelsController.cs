using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TobyLevelsController : MonoBehaviour
{
    public GameObject[] tobyCS;
    public int tobyIndex;
    public GameObject cutSceneToby, nextButton, playButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < tobyCS.Length; i++)
        if(i == tobyIndex)
        {
            tobyCS[i].SetActive(true);
        }
        else
        {
            tobyCS[i].SetActive(false);
        }
        
        if(tobyIndex == tobyCS.Length)
        {
            cutSceneToby.SetActive(false);
        }

        if(tobyIndex == 1)
        {
            nextButton.SetActive(true);
        }
        if(tobyIndex == 11)
        {
            nextButton.SetActive(false);
            Invoke("DelayPlay", 8f);
        }
    }
    
    public void NextCutScene()
    {
        nextButton.SetActive(false);
        tobyIndex++;
        Invoke("DelayNext", 5f);
    }
    public void DelayNext()
    {
        nextButton.SetActive(true);
    }
    public void DelayPlay()
    {
        playButton.SetActive(true);
    }

    public void TobyLevel1()
    {
        SceneManager.LoadScene("Toby1");
    }
    public void TobyLevel2()
    {
        SceneManager.LoadScene("Toby2");
    }
    public void TobyLevel3()
    {
        SceneManager.LoadScene("Toby3");
    }
    public void TobyLevel4()
    {
        SceneManager.LoadScene("Toby4");
    }
    public void TobyLevel5()
    {
        SceneManager.LoadScene("Toby5");
    }
    public void TobyLevel6()
    {
        SceneManager.LoadScene("Toby6");
    }


    
}
