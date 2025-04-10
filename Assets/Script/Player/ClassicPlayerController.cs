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
    public int starValue;

    [Header("Animation")]
    public Animator animator;

    [Header("Audio")]
    AudioManager audioManager;

    public int levelCurrent;
    private int LevelStars;

    public GameObject EndScene;

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

        levelCurrent = SceneManager.GetActiveScene().buildIndex;

        // Initialize health system
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            jumpRequest = true; // Set jump request flag
            animator.SetTrigger("jump");
            
        }

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.down * 100f;
        }

        if (Input.GetKeyDown(KeyCode.G) && isGrab || Input.GetKeyDown(KeyCode.Keypad0) && isGrab)  // Press G to collect item
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
                //ClassicPlayerController.instance.enabled = false;
                isGrounded = false;
                jumpRequest = false;
                isSpawned = false;
                if(SceneManager.GetActiveScene().buildIndex <= 20)
                {
                    Invoke("GameOverNaToby", 3f);
                }else if(SceneManager.GetActiveScene().buildIndex >= 21 && SceneManager.GetActiveScene().buildIndex <= 30)
                {
                    Invoke("GameOverNaTere", 3f);
                }
                else if(SceneManager.GetActiveScene().buildIndex >= 31 && SceneManager.GetActiveScene().buildIndex <= 40)
                {
                    Invoke("GameOverNaBoy", 3f);
                }
                
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

    public void JumpButton()
    {
        if (isGrounded)
        {
            jumpRequest = true; // Set jump request flag
            animator.SetTrigger("jump");
            
        }
    }

    public void DownButton()
    {
        rb.velocity = Vector2.down * 100f;
    }

    public void GrabButton()
    {
        if (isGrab)  // Press G to collect item
            {
                grabRequest = true;
                animator.SetTrigger("grab");
                audioManager.PlaySFX(audioManager.grab);
            }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Reset vertical velocity
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void GameOverNaToby()
    {
        SceneManager.LoadScene("TobbyGameOver");
    }
    public void GameOverNaTere()
    {
        SceneManager.LoadScene("TereGameOver");
    }
    public void GameOverNaBoy()
    {
        SceneManager.LoadScene("BoyGameOver");
    }

    public void Winner()
    {
        
        SceneManager.LoadScene("WinningScene");  // Load the Winning Scene
    }
    public void TereWinner()
    {
        
        SceneManager.LoadScene("TereWinning");  // Load the Winning Scene
    }
    public void BoyWinner()
    {
        
        SceneManager.LoadScene("BoyWinning");  // Load the Winning Scene
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
            if(SceneManager.GetActiveScene().buildIndex <= 19){
                Invoke("Winner", 5f);  // Trigger the Winner logic when reaching SafeZone
            }else if(SceneManager.GetActiveScene().buildIndex == 20)
            {
                Invoke("EndCutSCene", 5f);
                Invoke("Winner", 13f);
            }else if(SceneManager.GetActiveScene().buildIndex >= 21 && SceneManager.GetActiveScene().buildIndex <= 29)
            {
                Invoke("TereWinner", 5f);
            }else if(SceneManager.GetActiveScene().buildIndex == 30)
            {
                Invoke("EndCutSCene", 5f);
                Invoke("TereWinner", 20f);
            }else if(SceneManager.GetActiveScene().buildIndex >= 31 && SceneManager.GetActiveScene().buildIndex <= 39)
            {
                Invoke("BoyWinner", 5f);
                
            }else if(SceneManager.GetActiveScene().buildIndex == 40)
            {
                Invoke("EndCutSCene", 5f);
                Invoke("BoyWinner", 30f);
            }
            
            

            starManager.CollectStar();  // Award the third star
            PlayerPrefs.SetInt("TotalStars", starManager.totalStars);  // Save the star count
            PlayerPrefs.SetInt("Level" + levelCurrent + "TotalStars", starManager.totalStars);
            if(starManager.totalStars > PlayerPrefs.GetInt("Level" + levelCurrent + "finalLevelStar") && PlayerPrefs.GetInt("Level" + levelCurrent + "finalLevelStar") == 0)
            {
                PlayerPrefs.SetInt("Level" + levelCurrent + "finalLevelStar", starManager.totalStars);
            }
            else if(starManager.totalStars > PlayerPrefs.GetInt("Level" + levelCurrent + "finalLevelStar") && PlayerPrefs.GetInt("Level" + levelCurrent + "finalLevelStar") == 2)
            {
                PlayerPrefs.SetInt("Level" + levelCurrent + "finalLevelStar", starManager.totalStars - 2);
            }else if(starManager.totalStars > PlayerPrefs.GetInt("Level" + levelCurrent + "finalLevelStar") && starManager.totalStars == 3 && PlayerPrefs.GetInt("Level" + levelCurrent + "finalLevelStar") == 1)
            {
                PlayerPrefs.SetInt("Level" + levelCurrent + "finalLevelStar", starManager.totalStars - 1);
            }else if(starManager.totalStars > PlayerPrefs.GetInt("Level" + levelCurrent + "finalLevelStar") && starManager.totalStars == 2 && PlayerPrefs.GetInt("Level" + levelCurrent + "finalLevelStar") == 1)
            {
                PlayerPrefs.SetInt("Level" + levelCurrent + "finalLevelStar", starManager.totalStars - 1);
            }
            else{
                return;
            }

            LevelStars = PlayerPrefs.GetInt("Level" + levelCurrent + "finalLevelStar", 0); 
            starValue = PlayerPrefs.GetInt("FinalStar") + LevelStars;
            PlayerPrefs.SetInt("FinalStar", starValue);
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

    public void EndCutSCene()
    {
        EndScene.SetActive(true);
    }
    
}