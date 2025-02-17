using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUnlock : MonoBehaviour
{
    public int LevelCount;
    // Start is called before the first frame update
    void Start()
    {
        LevelCount = LockLevel.instance.levelAt += 1;
    }

    public void OnTriggerEnter(Collider col)
    {
        if(LevelCount > PlayerPrefs.GetInt("LevelAt"))
        {
            PlayerPrefs.SetInt("LevelAt", LevelCount);
        }
    }
}
