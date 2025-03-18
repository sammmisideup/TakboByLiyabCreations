using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TobyGameOverController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TobyLevel()
    {
        SceneManager.LoadScene("TobyLevels");
    }
    
    public void NanayLevel()
    {
        SceneManager.LoadScene("TereLevels");
    }

    public void TatayLevel()
    {
        SceneManager.LoadScene("BoyLevels");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
