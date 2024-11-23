using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectOnDestroy : MonoBehaviour
{
    public GameObject hiddenObject; 
    public GameObject targetPrefab; 

    private void Update()
    {
        if (targetPrefab == null && hiddenObject != null)
        {
            hiddenObject.SetActive(true);
            Debug.Log($"{hiddenObject.name} is now visible because {nameof(targetPrefab)} was destroyed.");
        }
    }
}
