using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockLevel : MonoBehaviour
{
    public static LockLevel instance;

    public Button[] levelButtons;
    public int levelAt;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        levelAt = PlayerPrefs.GetInt("LevelAt", 2);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 2 > levelAt)
            levelButtons[i].interactable = false;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("LevelAt");
            Debug.Log("Delete Prefs");
        }
    }

    
}
