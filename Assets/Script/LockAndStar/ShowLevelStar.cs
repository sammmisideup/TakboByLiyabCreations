using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLevelStar : MonoBehaviour
{[Header("Winning Scene UI")]
    public Image[] starImages;  // RawImages for stars in the winning scene

    private int LevelStars = 0;
    private int StarsLevel = 0;
    private int starValue;

    public Sprite GoldStar;

    public int CurrentLevel;

    void Start()
    {
        // Get the star count passed from PlayerPrefs (from ClassicPlayerController)
        LevelStars = PlayerPrefs.GetInt("Level" + CurrentLevel + "TotalStars", 0);

        if(LevelStars > PlayerPrefs.GetInt("StarLevel" + CurrentLevel + "TotalStars"))
        {
            PlayerPrefs.SetInt("StarLevel" + CurrentLevel + "TotalStars", LevelStars);
        }

        StarsLevel =  PlayerPrefs.GetInt("StarLevel" + CurrentLevel + "TotalStars", LevelStars);

        // Update the RawImage components in the winning scene to show the stars
        UpdateLevelStars(StarsLevel);
    
    }

    // Update the RawImages in the winning scene based on the total stars collected
    private void UpdateLevelStars(int StarsLevel)
    {
        for (int i = 0; i < starImages.Length; i++)
        {
            // Enable the star image for collected stars, and disable for uncollected
            if (i < StarsLevel)
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
        if(Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Delete All Prefs");
        }
    }
}
