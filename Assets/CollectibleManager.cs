using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [Header("Collectibles")]
    public GameObject[] collectibles;  // Array to hold all collectibles in the scene
    public int collectedCount = 0;     // Counter for how many collectibles the player has collected

    private bool hasCollectedSecondStar = false;  // Flag to prevent collecting the second star more than once

    public StarManager starManager;  // Reference to the StarManager to update the UI

    void Start()
    {
        // Initialize the collectibles array with all game objects tagged as "Collectibles"
        collectibles = GameObject.FindGameObjectsWithTag("Collectibles");
        Debug.Log("Total Collectibles Found: " + collectibles.Length);  // Debug line
    }

    // Call this method when the player collects a collectible
    public void CollectItem(GameObject collectible)
    {
        collectedCount++;  // Increment the collected item counter
        Destroy(collectible);  // Destroy the collected item

        Debug.Log("Collected: " + collectedCount + "/" + collectibles.Length);  // Debug line

        // Check if all collectibles have been collected and the second star hasn't been collected yet
        if (collectedCount == collectibles.Length && !hasCollectedSecondStar)
        {
            Debug.Log("All Collectibles Collected. Awarding Second Star...");  // Debug line
            starManager.CollectSecondStar();  // Call to award the second star
            hasCollectedSecondStar = true;  // Set the flag to prevent re-collection
        }
    }
}
