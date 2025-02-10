using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoider : MonoBehaviour
{
    public float offset = 50f;
    public float checkRadius = 1.0f; 

    private void Start()
    {
        Invoke(nameof(AvoidOverlap), 0.1f); 
    }

    private void AvoidOverlap()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius);
        foreach (Collider col in colliders)
        {
            if (col.gameObject != gameObject && col.CompareTag("Obstacle"))
            {
                float direction = Random.value > 0.5f ? 1f : -1f;
                Vector3 newPosition = transform.position + new Vector3(offset * direction, 0, 0);

                transform.position = newPosition;
                Debug.Log($"{gameObject.name} moved to avoid {col.gameObject.name}");
                break; 
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            float direction = Random.value > 0.5f ? 1f : -1f;
            transform.position += new Vector3(offset * direction, 0, 0);
            Debug.Log($"{gameObject.name} moved due to collision with {collision.gameObject.name}");
        }
    }
}
