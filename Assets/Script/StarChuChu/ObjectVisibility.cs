using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisibility : MonoBehaviour
{
    private void Start()
    {
        if (GameStateManager.Instance != null)
        {
            if (GameStateManager.Instance.IsObjectVisible(gameObject.name))
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
