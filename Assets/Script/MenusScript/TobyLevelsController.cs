using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TobyLevelsController : MonoBehaviour
{
    
    public GameObject TobyCutScene, skipButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    
    

    public void CutSCene()
    {
        TobyCutScene.SetActive(true);
        Invoke("DelaySkip", 10f);
        Invoke("TobyLevel1", 60f);
    }

    public void TereCutSCene()
    {
        TobyCutScene.SetActive(true);
        Invoke("DelaySkip", 10f);
        Invoke("TereLevel1", 43f);
    }

    public void BoyCutSCene()
    {
        TobyCutScene.SetActive(true);
        Invoke("DelaySkip", 10f);
        Invoke("BoyLevel1", 75f);
    }


    public void DelaySkip()
    {
        skipButton.SetActive(true);
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
    public void TobyLevel7()
    {
        SceneManager.LoadScene("Toby7");
    }
    public void TobyLevel8()
    {
        SceneManager.LoadScene("Toby8");
    }
    public void TobyLevel9()
    {
        SceneManager.LoadScene("Toby9");
    }
    public void TobyLevel10()
    {
        SceneManager.LoadScene("Toby10");
    }




    public void TereLevel1()
    {
        SceneManager.LoadScene("Tere1");
    }
    public void TereLevel2()
    {
        SceneManager.LoadScene("Tere2");
    }
    public void TereLevel3()
    {
        SceneManager.LoadScene("Tere3");
    }
    public void TereLevel4()
    {
        SceneManager.LoadScene("Tere4");
    }
    public void TereLevel5()
    {
        SceneManager.LoadScene("Tere5");
    }
    public void TereLevel6()
    {
        SceneManager.LoadScene("Tere6");
    }
    public void TereLevel7()
    {
        SceneManager.LoadScene("Tere7");
    }
    public void TereLevel8()
    {
        SceneManager.LoadScene("Tere8");
    }
    public void TereLevel9()
    {
        SceneManager.LoadScene("Tere9");
    }
    public void TereLevel10()
    {
        SceneManager.LoadScene("Tere10");
    }




    public void BoyLevel1()
    {
        SceneManager.LoadScene("Boy1");
    }
    public void BoyLevel2()
    {
        SceneManager.LoadScene("Boy2");
    }
    public void BoyLevel3()
    {
        SceneManager.LoadScene("Boy3");
    }
    public void BoyLevel4()
    {
        SceneManager.LoadScene("Boy4");
    }
    public void BoyLevel5()
    {
        SceneManager.LoadScene("Boy5");
    }
    public void BoyLevel6()
    {
        SceneManager.LoadScene("Boy6");
    }
    public void BoyLevel7()
    {
        SceneManager.LoadScene("Boy7");
    }
    public void BoyLevel8()
    {
        SceneManager.LoadScene("Boy8");
    }
    public void BoyLevel9()
    {
        SceneManager.LoadScene("Boy9");
    }
    public void BoyLevel10()
    {
        SceneManager.LoadScene("Boy10");
    }


    
}
