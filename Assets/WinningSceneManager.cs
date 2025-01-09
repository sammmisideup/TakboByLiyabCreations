using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class WinningSceneManager : MonoBehaviour
{
    [Header("Winning Scene UI")]
    public RawImage[] starImages;  // RawImages for stars in the winning scene

    void Start()
    {
        // Get the star count passed from PlayerPrefs (from ClassicPlayerController)
        int totalStars = PlayerPrefs.GetInt("TotalStars", 0);

        // Update the RawImage components in the winning scene to show the stars
        UpdateWinningStars(totalStars);
    }

    // Update the RawImages in the winning scene based on the total stars collected
    private void UpdateWinningStars(int totalStars)
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
    public void NextLevel()
    {
        SceneManager.LoadScene("TobyLevels");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
