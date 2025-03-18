using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TobyLockLevel : MonoBehaviour
{
    public GameObject[] levelButtons;
    public int sceneLock;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        sceneLock = PlayerPrefs.GetInt("sceneLock", 11);

        for (i = 0; i < levelButtons.Length; i++)
        {
            if(i + 11 > sceneLock)
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
