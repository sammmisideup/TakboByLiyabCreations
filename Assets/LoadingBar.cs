using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For scene management

public class LoadingBar : MonoBehaviour
{
    public Transform loadingBarImage; // Reference to the loading bar image
    public string nextSceneName = "StartScreen"; // Set this in the Inspector
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
            CurrentAmount = Mathf.Clamp(CurrentAmount + speed * Time.deltaTime, 0, TargetAmount);
            if (loadingBarImage != null)
            {
                Image barImage = loadingBarImage.GetComponent<Image>();
                if (barImage != null)
                {
                    barImage.fillAmount = CurrentAmount / TargetAmount;
                }
            }
        }
        else
        {
            // Once the bar is full, transition to the specified scene
            LoadNextScene();
        }
    }

    // Method to load the next scene
    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set in the Inspector!");
        }
    }
}
