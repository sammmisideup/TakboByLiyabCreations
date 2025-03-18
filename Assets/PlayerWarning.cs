using System.Collections;
using UnityEngine;

public class PlayerWarning : MonoBehaviour
{
    public GameObject warningIcon;
    public AudioSource audioSource; // Reference to the AudioSource
    public AudioClip warningSound;  // Sound clip to play

    private bool isWarningActive = false;
    public float warningDuration = 3f; 
    public float blinkInterval = 0.5f;

    private void Start()
    {
        if (warningIcon != null)
            warningIcon.SetActive(false);

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>(); // Get AudioSource if not assigned
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);
        if (other.CompareTag("MovingObstacle") && !isWarningActive)
        {
            StartCoroutine(BlinkWarning());
        }
    }

    private IEnumerator BlinkWarning()
    {
        Debug.Log("Showing blinking warning");
        isWarningActive = true;
        float elapsedTime = 0f;

        // Play warning sound when first activated
        if (audioSource != null && warningSound != null)
        {
            audioSource.PlayOneShot(warningSound);
        }

        while (elapsedTime < warningDuration)
        {
            if (warningIcon != null)
                warningIcon.SetActive(!warningIcon.activeSelf); // Toggle visibility

            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        if (warningIcon != null)
            warningIcon.SetActive(false); // Ensure it's off after blinking

        isWarningActive = false;
        Debug.Log("Warning hidden");
    }
}
