using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLevelStar : MonoBehaviour
{[Header("Winning Scene UI")]
    public Image[] starImages;  // RawImages for stars in the winning scene

    private int LevelStars = 0;
    private int starValue;

    public Sprite GoldStar;

    public int CurrentLevel;

    void Start()
    {
        // Get the star count passed from PlayerPrefs (from ClassicPlayerController)
        LevelStars = PlayerPrefs.GetInt("Level" + CurrentLevel + "TotalStars", 0);

        // Update the RawImage components in the winning scene to show the stars
        UpdateLevelStars(LevelStars);
    
    }

    // Update the RawImages in the winning scene based on the total stars collected
    private void UpdateLevelStars(int LevelStars)
    {
        for (int i = 0; i < starImages.Length; i++)
        {
            // Enable the star image for collected stars, and disable for uncollected
            if (i < LevelStars)
            {
                //starImages[i].gameObject.SetActive(true);  // Show star
                starImages[i].sprite = GoldStar;
            }
            else
            {
                //starImages[i].gameObject.SetActive(false);  // Hide star
            }
        }


    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("Level" + CurrentLevel + "TotalStars");
            Debug.Log("Delete Prefs");
        }
    }
}
