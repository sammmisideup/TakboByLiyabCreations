using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    private HashSet<string> visibleObjects = new HashSet<string>();
    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
  
    public void MarkObjectVisible(string objectName)
    {
        visibleObjects.Add(objectName);
    }

    public bool IsObjectVisible(string objectName)
    {
        return visibleObjects.Contains(objectName);
    }
}
