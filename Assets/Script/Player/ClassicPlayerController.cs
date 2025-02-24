using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassicPlayerController : MonoBehaviour
{
    public static ClassicPlayerController instance;
    [Header("Player Movement")]
    public Rigidbody rb;
    public float jumpForce;
    private float jumpDown = 80f;
    public bool isGrounded = false;
    public bool jumpRequest = false;
    public bool isGrab = false;
    public bool grabRequest= false;
    

    [Header("Player Health")]
    public Vector3 playerSpawner;
    public bool isSpawned;
    public GameObject heart1, heart2, heart3;
    public static int health;

    [Header("Star System")]
    public StarManager starManager;  // Reference to StarManager to update the star count
    public CollectibleManager collectibleManager;  // Reference to CollectibleManager for item collection
    private bool hasCollectedStar = false;

    [Header("Animation")]
    public Animator animator;

    [Header("Animation")]
    AudioManager audioManager;

    private void Awake()
    {   
        if(instance == null)
            instance= this;

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.useGravity = true;
        playerSpawner = transform.position;
        isSpawned = true;

        // Initialize health system
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }    

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequest = true; // Set jump request flag
            animator.SetTrigger("jump");
            
        }

        if (Input.GetKeyDown(KeyCode.G) && isGrab)  // Press G to collect item
            {
                grabRequest = true;
                animator.SetTrigger("grab");
                audioManager.PlaySFX(audioManager.grab);
            }

        
        
        // Player Health System
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
                animator.SetTrigger("dead");
                ClassicMapForce.instance.classicMapSpeed = 0;
                isGrounded = false;
                jumpRequest = false;
                isSpawned = false;
                Invoke("GameOverNa", 3f);
                break;
        }
    }

      void FixedUpdate()
    {
        // Player Jump
        if (jumpRequest && isGrounded)
        {
            Jump();
            jumpRequest = false; // Reset jump request
        }
        else
        {
            rb.AddForce(Vector3.down * jumpDown, ForceMode.Force);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Reset vertical velocity
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void GameOverNa()
    {
        SceneManager.LoadScene("TobbyGameOver");
    }

    public void Winner()
    {
        
        SceneManager.LoadScene("WinningScene");  // Load the Winning Scene
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "FallingObject")
        {
            isGrounded = true;
            audioManager.Play2SFX(audioManager.run);
        }
        if (col.gameObject.tag == "Obstacle")
        {
            health -= 1;
            Destroy(col.gameObject, 0.2f);
            animator.SetTrigger("recoil");
            audioManager.PlaySFX(audioManager.recoil);
        }
        if (col.gameObject.tag == "MovingObstacle")
        {
            health -= 1;
            Destroy(col.gameObject, 0.2f);
            animator.SetTrigger("recoil");
            audioManager.PlaySFX(audioManager.recoil);
        }

        if (col.gameObject.tag == "ObstacleBelow" && isSpawned)
        {
            health -= 1;
            Invoke("SpawnPlayer", 1f);
            animator.SetTrigger("recoil");
            audioManager.PlaySFX(audioManager.recoil);
        }

        // Check for star collection
        if (col.gameObject.CompareTag("Star") && !hasCollectedStar)
        {
            hasCollectedStar = true;
            starManager.CollectStar();  // Collect first star
            Destroy(col.gameObject);   // Destroy the star object
            audioManager.PlaySFX(audioManager.star);
        }

        if (col.gameObject.tag == "Collectibles")
        {
            isGrab = true;
        }

        if (col.gameObject.tag == "SafeZone")
        {
            Debug.Log("SafeZone Reached! Collecting Third Star...");
            animator.SetTrigger("win");
            ClassicMapForce.instance.classicMapSpeed = 0;
            Invoke("Winner", 5f);  // Trigger the Winner logic when reaching SafeZone

            starManager.CollectStar();  // Award the third star
            PlayerPrefs.SetInt("TotalStars", starManager.totalStars);  // Save the star count
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Collectibles")
        {
            isGrab = false;
        }

        if (col.gameObject.tag == "FallingObject")
        {
            isGrounded = false; // Set isGrounded to false when leaving the ground
            animator.SetBool("run", false);
            audioManager.StopSFX(audioManager.run);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("Is Grounded: " + isGrounded);
            animator.SetBool("run", true);
            audioManager.Play2SFX(audioManager.run);
        }
        if (collision.gameObject.tag == "MovingObstacle")
        {
            isGrounded = true;
            Debug.Log("Is Grounded: " + isGrounded);
            animator.SetBool("run", true);
            //audioManager.Play2SFX(audioManager.run);
        }

        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false; // Set isGrounded to false when leaving the ground
            animator.SetBool("run", false);
            audioManager.StopSFX(audioManager.run);
        }
        if (collision.gameObject.tag == "MovingObstacle")
        {
            isGrounded = false; // Set isGrounded to false when leaving the ground
            animator.SetBool("run", false);
            //audioManager.StopSFX(audioManager.run);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true; // Set isGrounded to false when leaving the ground
            animator.SetBool("run", true);
        }
    }


    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Collectibles")
        {
            if (grabRequest)  // Press G to collect item
            {
                collectibleManager.CollectItem(col.gameObject);
                grabRequest = false;
                isGrab = false;
            }
        }
    }

    void SpawnPlayer()
    {
        if(isSpawned)
        {
            transform.position = playerSpawner;
        }
        else
        {
            return;
        }
        
    }
}