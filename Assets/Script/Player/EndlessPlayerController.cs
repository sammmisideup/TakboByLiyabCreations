using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndlessPlayerController : MonoBehaviour
{
    public static EndlessPlayerController instance;

    public Rigidbody rb;
    public float jumpForce;
    private float jumpDown = 80f;

    public bool isGrounded = false;
    public bool jumpRequest = false;
    public bool isGrab = false;
    public bool grabRequest= false;

    public Vector3 playerSpawner;

    public Image timerStamina;
    public float timeRemaining;
    public float maxTime;
    public float addedEnergy;
    public float minusEnergy;

    [SerializeField] private ParticleSystem ItemsSmokeParticle = default;
    public Gradient gradient;

    public TextMeshProUGUI scoreText;
    public float scoreValue = 0f;

    [Header("Animation")]
    public Animator tobyAnimator;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tobyAnimator = GetComponent<Animator>();
        rb.useGravity = true;
        playerSpawner = transform.position;
        timeRemaining = maxTime;

        // Safety check for timerStamina
        if (timerStamina == null)
        {
            Debug.LogError("timerStamina is NULL! Make sure to assign it in the Inspector.");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequest = true; // Set jump request flag
            tobyAnimator.SetTrigger("jump");
        }

        if (Input.GetKeyDown(KeyCode.G) && isGrab)  // Press G to collect item
        {
            grabRequest = true;
            tobyAnimator.SetTrigger("grab");
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            
            // Ensure timerStamina is not null before using it
            if (timerStamina != null)
            {
                timerStamina.fillAmount = timeRemaining / maxTime;
                timerStamina.color = gradient.Evaluate(timerStamina.fillAmount);
            }
        }

        if (timeRemaining <= 0)
        {
            tobyAnimator.SetTrigger("dead");
            isGrounded = false;
            timerStamina.fillAmount = 0;

            if (PlatformSpawner.instance != null)
                PlatformSpawner.instance.enabled = false;
            
            if (ParallaxBG2.instance != null)
                ParallaxBG2.instance.enabled = false;

            Invoke("GameOverNa", 3f);
        }

        if (scoreText != null)
        {
            scoreText.text = ((int)scoreValue).ToString();
        }
        
        scoreValue += 1f * Time.deltaTime;
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

    public void JumpButton()
    {
        if (isGrounded)
        {
            jumpRequest = true; // Set jump request flag
            tobyAnimator.SetTrigger("jump");
            
        }
    }

    public void GrabButton()
    {
        if (isGrab)  // Press G to collect item
            {
                grabRequest = true;
                tobyAnimator.SetTrigger("grab");
                
            }
    }

    public void GameOverNa()
    {
        PlayerPrefs.SetInt("playerfinalscore", (int)scoreValue);

        if (scoreValue > PlayerPrefs.GetInt("finalhighscore"))
        {
            PlayerPrefs.SetInt("finalhighscore", (int)scoreValue);
        }

        SceneManager.LoadScene("GameOverTobbyEndless");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Obstacle") || col.gameObject.CompareTag("MovingObstacle") || col.gameObject.CompareTag("FlyingObstacle"))
        {
            timeRemaining -= minusEnergy;
            Destroy(col.gameObject, 0.3f);
            tobyAnimator.SetTrigger("recoil");
        }
        else if (col.gameObject.CompareTag("ObstacleBelow"))
        {
            timeRemaining -= minusEnergy;
            Invoke("SpawnPlayer", 1f);
        }
        else if (col.gameObject.CompareTag("SpeedUp") && EndlessMapForce.instance != null)
        {
            EndlessMapForce.instance.endlessMapSpeed += 10f;
        }
        else if (col.gameObject.CompareTag("SpeedDown") && EndlessMapForce.instance != null)
        {
            EndlessMapForce.instance.endlessMapSpeed -= 10f;
        }
        else if (col.gameObject.CompareTag("Stamina"))
        {
            isGrab = true;
        }
    }

    void SpawnPlayer()
    {
        transform.position = playerSpawner;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            tobyAnimator.SetBool("run", true);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            tobyAnimator.SetBool("run", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            tobyAnimator.SetBool("run", false);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Stamina"))
        {
            if (grabRequest)
            {
                timeRemaining += addedEnergy;
                timeRemaining = Mathf.Clamp(timeRemaining, 0, maxTime);
                
                if (timerStamina != null)
                {
                    timerStamina.fillAmount = timeRemaining / maxTime;
                }

                if (ItemsSmokeParticle != null)
                {
                    ItemsSmokeParticle.Play();
                }
                
                Destroy(col.gameObject);
                grabRequest = false;
                isGrab = false;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Stamina"))
        {
            isGrab = false;
        }
    }
}
