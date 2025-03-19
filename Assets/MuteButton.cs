using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    private bool isMuted = false;
    public Button muteButton;
    public GameObject panel; // Assign the panel in the Inspector

    void Start()
    {
        // Ensure the button is assigned
        if (muteButton != null)
        {
            muteButton.onClick.AddListener(ToggleMute);
            UpdateButtonText();
        }
    }

    void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1;
        UpdateButtonText();

        // Ensure the panel stays active
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }

    void UpdateButtonText()
    {
        Text buttonText = muteButton.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.text = isMuted ? "Unmute" : "Mute";
        }
    }
}
