using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 7f;
    public float jumpDown = 10f;

    public bool isGrounded = false;

    public GameObject Grab;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        else
        {
            rb.AddForce(Vector3.down * jumpDown, ForceMode.Force);
        }
    }

    //Tatalon si player
    void Jump()
    {
        isGrounded = false;
        rb.velocity = new Vector3(0, 0f,0);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    //titignan kung nasa ground si player para makatalon
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        } 
    }

    //Okay na ito 
    //Pag nag collide sa item ma pipindot yung grab
    private void OnTriggerStay(Collider col)
    {
        GameObject whatHit = col.gameObject;
        if(col.gameObject.tag == "Stamina")
        {
            Debug.Log("press");
            Grab.SetActive(true);
            if(Input.GetButtonDown("Grab"))
            {
                Grab.SetActive(false);
                Destroy(col.gameObject);
                Debug.Log("EnergyDestroy");
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        GameObject whatHit = col.gameObject;
        if(whatHit.CompareTag("Stamina"))
        {
            Grab.SetActive(false);
            Debug.Log("Exit");
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Obstacle")
        {
            PlayerController.health -= 1;
        }
    }


 


}
