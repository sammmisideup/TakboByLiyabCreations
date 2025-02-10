using System.Collections;
using UnityEngine;

public class PlayerWarning : MonoBehaviour
{
    public GameObject warningIcon; 
    private bool isWarningActive = false;

    private void Start()
    {
        if (warningIcon != null)
            warningIcon.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);
        if (other.CompareTag("MovingObstacle") && !isWarningActive)
        {
            StartCoroutine(ShowWarning());
        }
    }

    private IEnumerator ShowWarning()
    {
        Debug.Log("Showing warning");
        isWarningActive = true;
        if (warningIcon != null)
            warningIcon.SetActive(true);
        
        yield return new WaitForSeconds(3f);
        
        if (warningIcon != null)
            warningIcon.SetActive(false);
        
        isWarningActive = false;
        Debug.Log("Warning hidden");
    }
}
