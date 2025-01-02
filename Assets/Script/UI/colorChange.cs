using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorChange : MonoBehaviour
{

    public Image imageColor;
    public Color color1, color2;
    Color targetColor;

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
                targetColor = color2;
                isChangeColor = false;
            
        }
        if(isChangeColor == false)
        {
            Invoke("backColor", 1f);
        }
        imageColor.color = Color.Lerp(imageColor.color, targetColor, 0.1f);
        
    }

    private void OnTriggerEnter(Collider col)
    {
        GameObject whatHit = col.gameObject;
        if(col.gameObject.tag == "Player")
        {
            isChangeColor = true;
            
        };
    }

    public void backColor()
    {
        targetColor = color1;
        isChangeColor = false;
    }

    

}
