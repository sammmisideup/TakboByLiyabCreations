using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessPlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 7f;
    public float jumpDown = 10f;

    public bool isGrounded = false;

    public GameObject Grab;

    public GameObject gameOver;
    
    public GameObject playerDied;
    public Vector3 playerSpawner;

    public Image timerStamina;
    float timeRemaining;
    public float maxTime;
    public float addedEnergy;
    public float minusEnergy;

    [SerializeField] private ParticleSystem ItemsSmokeParticle = default;
    public Gradient gradient;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerSpawner = transform.position;

        gameOver.gameObject.SetActive(false);

        // For Energy
        timeRemaining = maxTime;

        
        
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

        // Pagbwas ng Energy
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerStamina.fillAmount = timeRemaining / maxTime;
        }
        
        timerStamina.color = gradient.Evaluate(timerStamina.fillAmount);

        if(timeRemaining <= 0)
        {
            Invoke("GameOverNa", 0.3f);
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
            timeRemaining -= minusEnergy;
            Destroy(col.gameObject, 0.3f);
            
        }
        if(col.gameObject.tag == "ObstacleBelow")
        {
            timeRemaining -= minusEnergy;
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
                timeRemaining += addedEnergy;
                timeRemaining = Mathf.Clamp(timeRemaining, 0, maxTime);
                timerStamina.fillAmount = timeRemaining / maxTime;
            

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
