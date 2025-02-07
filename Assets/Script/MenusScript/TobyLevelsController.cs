using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TobyLevelsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TobyLevel1()
    {
        SceneManager.LoadScene("Toby1");
    }
    public void TobyLevel2()
    {
        SceneManager.LoadScene("Toby2");
    }
    public void TobyLevel3()
    {
        SceneManager.LoadScene("Toby3");
    }
    public void TobyLevel4()
    {
        SceneManager.LoadScene("Toby4");
    }
    public void TobyLevel5()
    {
        SceneManager.LoadScene("Toby5");
    }
    public void TobyLevel6()
    {
        SceneManager.LoadScene("Toby6");
    }
}
