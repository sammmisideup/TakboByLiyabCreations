using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For scene management

public class LoadingBar : MonoBehaviour
{
    public Transform loadingBarImage; // Reference to the loading bar image
    public float TargetAmount = 100.0f; // Target amount to reach
    public float speed = 30; // Speed at which the bar fills

    private float CurrentAmount = 0.0f; // Current progress

    // Start is called before the first frame update
    void Start()
    {
        CurrentAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Fill the loading bar
        if (CurrentAmount < TargetAmount)
        {
            CurrentAmount += speed * Time.deltaTime;
            loadingBarImage.GetComponent<Image>().fillAmount = CurrentAmount / 100.0f;
        }
        else
        {
            // Once the bar is full, transition to the next scene
            LoadNextScene();
        }
    }

    // Method to load the next scene
    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Get current scene index
        SceneManager.LoadScene("StartScreen"); // Load the next scene in the build order
    }
}
