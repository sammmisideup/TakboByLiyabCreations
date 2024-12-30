using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void CreditsScreen()
    {
        SceneManager.LoadScene("CreditsScreen");
    }
    public void SettingsScreen()
    {
        SceneManager.LoadScene("SettingsScreen");
    }
        public void StartMenu()
    {
        SceneManager.LoadScene("GameMode");
    }
    public void StoryMode()
    {
        SceneManager.LoadScene("StoryMode");
    }
        public void QuitGame()
    {
        Debug.Log("quit sha");
        Application.Quit();
    }
}
