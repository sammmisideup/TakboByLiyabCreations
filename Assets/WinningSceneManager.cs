using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;  

public class WinningSceneManager : MonoBehaviour
{
    [Header("Winning Scene UI")]
    public RawImage[] starImages;  // RawImages for stars in the winning scene

    public TextMeshProUGUI  finalStar;
    private int totalStars = 0;
    private int starValue;

    void Start()
    {
        // Get the star count passed from PlayerPrefs (from ClassicPlayerController)
        totalStars = PlayerPrefs.GetInt("TotalStars", 0);
        finalStar.text = PlayerPrefs.GetInt("FinalStar").ToString();
        //starValue = PlayerPrefs.GetInt("FinalStar");
        // Update the RawImage components in the winning scene to show the stars
        UpdateWinningStars(totalStars);
        // StarText();
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

    // public void AddStar()
    // {
    //     starValue = starValue + totalStars;
    //     PlayerPrefs.SetInt("FinalStar", starValue);
        

    //     PlayerPrefs.Save();

    //     StarText();
        
    // }

    // private void StarText()
    // {
    //     if(finalStar != null)
    //     finalStar.text = starValue.ToString();
    // }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("FinalStar");
            Debug.Log("Delete Prefs");
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
