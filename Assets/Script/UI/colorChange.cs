using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorChange : MonoBehaviour
{

    public Image imageColor;
    public Color color1, color2;
    Color targetColor;
    public float speedChange;

    public bool isChangeColor;
    // Start is called before the first frame update
    void Start()
    {
        imageColor.color = color1;
        targetColor = color1;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(isChangeColor == true)
        {
                imageColor.color = Color.Lerp(imageColor.color, targetColor, 0.3f);
                Invoke("backColor", 0.5f);
        }  
        
    }

    private void OnTriggerEnter(Collider col)
    {
        GameObject whatHit = col.gameObject;
        if(col.gameObject.tag == "Player")
        {
            isChangeColor = true;
            targetColor = color2;
        };
    }

    public void backColor()
    {
        targetColor = color1;
        imageColor.color = Color.Lerp(imageColor.color, targetColor, speedChange);
        isChangeColor = false;
    }

    

}
