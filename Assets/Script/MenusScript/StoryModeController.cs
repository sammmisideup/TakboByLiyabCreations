using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class StoryModeController : MonoBehaviour
{
    public int starValueMap;
    public GameObject Lock1, Lock2;
    // Start is called before the first frame update
    void Start()
    {
        
        starValueMap = PlayerPrefs.GetInt("FinalStar");
        
    }

    public void unlockTereMap()
    {
        if(starValueMap >= 3)
        {
            Lock1.SetActive(false);
            starValueMap -= 3;
            PlayerPrefs.SetInt("FinalStar", starValueMap);
        }
        
    }
    public void unlockBoyMap()
    {
        if(starValueMap >= 25)
        {
            Lock2.SetActive(false);
            starValueMap -= 25;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TobyLevel()
    {
        SceneManager.LoadScene("TobyLevels");
    }
    
    public void NanayLevel()
    {
        SceneManager.LoadScene("TereLevels");
    }

    public void TatayLevel()
    {
        SceneManager.LoadScene("BoyLevels");
    }
}
