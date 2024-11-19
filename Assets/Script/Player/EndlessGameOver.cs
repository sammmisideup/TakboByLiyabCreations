using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndlessGameOver : MonoBehaviour
{
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI playerHighScore;
    // Start is called before the first frame update
    void Start()
    {
        playerScore.text = PlayerPrefs.GetInt("playerfinalscore").ToString();
        playerHighScore.text = PlayerPrefs.GetInt("finalhighscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Reset()
    {
        PlayerPrefs.DeleteKey("finalhighscore");
    }

    public void EndlessTryAgain()
    {
        SceneManager.LoadScene("EndlessMode");
    }

    public void EndlessBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
