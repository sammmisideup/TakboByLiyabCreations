using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobyCutScene : MonoBehaviour
{
    public GameObject[] tobyCS;
    public int tobyIndex;
    public GameObject cutSceneToby;

    void Update()
    {
        for(int i = 0; i < tobyCS.Length; i++)
        if(i == tobyIndex)
        {
            tobyCS[i].SetActive(true);
        }
        else
        {
            tobyCS[i].SetActive(false);
        }
        
        if(tobyIndex == tobyCS.Length)
        {
            cutSceneToby.SetActive(false);
        }
    }

    public void NextCutScene()
    {
        tobyIndex++;
    }








}
