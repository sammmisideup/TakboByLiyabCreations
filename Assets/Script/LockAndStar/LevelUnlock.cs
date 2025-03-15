using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUnlock : MonoBehaviour
{
    public int LevelCount;
    public int LevelNext;
    // Start is called before the first frame update
    void Start()
    {
        LevelCount = SceneManager.GetActiveScene().buildIndex + 1;
        LevelNext = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter(Collider col)
    {
        if(LevelCount > PlayerPrefs.GetInt("LevelAt"))
        {
            PlayerPrefs.SetInt("LevelAt", LevelCount);
        }

        if(LevelNext > PlayerPrefs.GetInt("sceneLock"))
        {
            PlayerPrefs.SetInt("sceneLock", LevelNext);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 18)
        {
            PlayerPrefs.SetInt("sceneLock", LevelNext + 1);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 29)
        {
            PlayerPrefs.SetInt("sceneLock", LevelNext + 1);
        }

        // if(LevelNext > PlayerPrefs.GetInt("tereSceneLock"))
        // {
        //     PlayerPrefs.SetInt("tereSceneLock", LevelNext);
        // }
        
    }
    

    
}
