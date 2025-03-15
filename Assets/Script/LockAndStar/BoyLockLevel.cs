using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoyLockLevel : MonoBehaviour
{
    public GameObject[] levelButtons;
    public int boySceneLock;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        boySceneLock = PlayerPrefs.GetInt("sceneLock", 31);

        for (i = 0; i < levelButtons.Length; i++)
        {
            if(i + 31 > boySceneLock)
            levelButtons[i].SetActive(true);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("sceneLock");
            Debug.Log("Delete Prefs");
        }
    }
}
