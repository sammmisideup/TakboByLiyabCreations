using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndlessPlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public Rigidbody rb;
    public float jumpForce;
    private float jumpDown = 80f;

    public bool isGrounded = false;

    [Space(10)]
    [Header("Getting Items and Obstacles?")]
    //public GameObject Grab;

    
    
    public Vector3 playerSpawner;
    //public Rigidbody FallingObject;


    [Space(10)]
    [Header("Player Energy")]
    public Image timerStamina;
    float timeRemaining;
    public float maxTime;
    public float addedEnergy;
    public float minusEnergy;

    [SerializeField] private ParticleSystem ItemsSmokeParticle = default;
    public Gradient gradient;

    [Space(10)]
    [Header("PLayer Score")]
    public TextMeshProUGUI scoreText;
    public float scoreValue = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        playerSpawner = transform.position;


        // For Energy
        timeRemaining = maxTime;
        
    }

    void FixedUpdate()
    {
        // Player Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.velocity = new Vector3(0, 0f, 0);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(Vector3.down * jumpDown, ForceMode.Force);
        }
    }

    void Update()
    {

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

        //score ng player
        scoreText.text = ((int)scoreValue).ToString();
        scoreValue += 1f *  Time.deltaTime;

        
    }
    
    //GameOver
    public void GameOverNa()
    {
        PlayerPrefs.SetInt("playerfinalscore", (int)scoreValue);

        if (scoreValue > PlayerPrefs.GetInt("finalhighscore"))
        {
            PlayerPrefs.SetInt("finalhighscore", (int)scoreValue);   
        }

        SceneManager.LoadScene("GameOverTobbyEndless");
        //Time.timeScale = 0;
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
        if(col.gameObject.tag == "SpeedUp")
        {
           EndlessMapForce.instance.endlessMapSpeed += 10f;
           Debug.Log("SpeedUp");
        }
        if(col.gameObject.tag == "SpeedDown")
        {
            EndlessMapForce.instance.endlessMapSpeed -= 10f;
        }
        // if(col.gameObject.tag == "FallingObject")
        // {
        //     FallingObject.isKinematic = false;
        // }
        
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


        // if(collision.gameObject.tag == "FallingObject")
        // {
        //     FallingObject.isKinematic = false;
        // }
    }

    //Okay na ito 
    //Pag nag collide sa item ma pipindot yung grab
    private void OnTriggerStay(Collider col)
    {
        GameObject whatHit = col.gameObject;
        if(col.gameObject.tag == "Stamina")
        {   
            Debug.Log("press");
            //Grab.SetActive(true);
            if(Input.GetButtonDown("Grab"))
            {
                timeRemaining += addedEnergy;
                timeRemaining = Mathf.Clamp(timeRemaining, 0, maxTime);
                timerStamina.fillAmount = timeRemaining / maxTime;
            

                ItemsSmokeParticle.Play();
                //Grab.SetActive(false);
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
            //Grab.SetActive(false);
            Debug.Log("Exit");
        }
    }
    

    
    
 


}
