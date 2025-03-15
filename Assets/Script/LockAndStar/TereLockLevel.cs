using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TereLockLevel : MonoBehaviour
{
    public GameObject[] levelButtons;
    public int tereSceneLock;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        tereSceneLock = PlayerPrefs.GetInt("sceneLock", 20);

        for (i = 0; i < levelButtons.Length; i++)
        {
            if(i + 20 > tereSceneLock)
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
