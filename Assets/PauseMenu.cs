using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed!"); // Debug log to check key input
            TogglePause();
        }
    }

    public void TogglePause()
    {
        bool isPaused = pauseMenu.activeSelf; // Check if pause menu is active

        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);  // Show pause menu
        Time.timeScale = 0;         // Freeze the game
    }

    public void Resume()
    {
        pauseMenu.SetActive(false); // Hide pause menu
        Time.timeScale = 1;         // Resume the game
    }

    public void Home()
    {
        Time.timeScale = 1; // Ensure time resumes before switching scenes
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Time.timeScale = 1; // Ensure time resumes before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
