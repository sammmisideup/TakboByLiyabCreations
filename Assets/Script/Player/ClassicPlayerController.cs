using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicPlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 7f;
    public float jumpDown = 10f;

    public bool isGrounded = false;

    public GameObject Grab;

    public GameObject heart1, heart2, heart3;
    public GameObject gameOver;
    public static int health;
    public GameObject playerDied;
    public Vector3 playerSpawner;

    [SerializeField] private ParticleSystem ItemsSmokeParticle = default;

    

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerSpawner = transform.position;

        gameOver.gameObject.SetActive(false);

        // For player Health System
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        

        
        
    }

    void Update()
    {
        //Player Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        else
        {
            rb.AddForce(Vector3.down * jumpDown, ForceMode.Force);
        }

        //Player Health System
        if(health > 3)
           health = 3;
        
        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                Invoke("GameOverNa", 0.5f);
                break;
        }
    }

    //Tatalon si player
    void Jump()
    {
        isGrounded = false;
        rb.velocity = new Vector3(0, 0f,0);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    public void GameOverNa()
    {
        gameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnTriggerEnter(Collider col)
    {
        GameObject whatHit = col.gameObject;
        if(col.gameObject.tag == "Obstacle")
        {
            health -= 1;
            Destroy(col.gameObject, 0.3f);
            
        }
        if(col.gameObject.tag == "ObstacleBelow")
        {
            health -= 1;
            Invoke("SpawnPlayer", 1f);
        }
    }

    void SpawnPlayer()
    {
        transform.position = playerSpawner;
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
                ItemsSmokeParticle.Play();
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

    
    
 


}
