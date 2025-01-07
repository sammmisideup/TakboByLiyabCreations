using UnityEngine;
using UnityEngine.UI;  // Required for RawImage components

public class StarManager : MonoBehaviour
{
    [Header("Star System")]
    public int totalStars = 0;  // Total number of stars collected
    public RawImage[] starImages;  // RawImages to represent the stars in the UI (3 images for 3 stars)

    [Header("Collectible System")]
    public CollectibleManager collectibleManager;  // Reference to CollectibleManager

    void Start()
    {
        UpdateStarUI();  // Initialize the star UI at the start
    }

    // Method to collect a regular star (e.g., when a star object is collected)
    public void CollectStar()
    {
        totalStars++;  // Increment the star count
        Debug.Log("Star Collected! Total Stars: " + totalStars);
        UpdateStarUI();  // Update the UI to reflect the new star count
    }

    // Method to collect the second star (e.g., when all collectibles are collected)
    public void CollectSecondStar()
    {
        totalStars++;  // Increment the star count
        Debug.Log("Second Star Collected! Total Stars: " + totalStars);
        UpdateStarUI();  // Update the UI to reflect the new star count
    }

    // Update the RawImage components to show the current number of stars
    private void UpdateStarUI()
    {
        for (int i = 0; i < starImages.Length; i++)
        {
            // Enable the star image for collected stars, and disable for uncollected
            if (i < totalStars)
            {
                starImages[i].gameObject.SetActive(true);  // Show star
            }
            else
            {
                starImages[i].gameObject.SetActive(false);  // Hide star
            }
        }
    }
}
