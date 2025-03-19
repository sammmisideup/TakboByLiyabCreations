using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  

public class ShowTotalStar : MonoBehaviour
{

    public TextMeshProUGUI  finalStar;
    // Start is called before the first frame update
    void Start()
    {
        finalStar.text = PlayerPrefs.GetInt("FinalStar").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("FinalStar");
            
            Debug.Log("Delete Prefs");
        }
    }
}
