using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndlessPlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    private float jumpDown = 80f;

    public bool isGrounded = false;
    public bool jumpRequest = false;
    public bool isGrab = false;
    public bool grabRequest= false;


    public Vector3 playerSpawner;

    public Image timerStamina;
    float timeRemaining;
    public float maxTime;
    public float addedEnergy;
    public float minusEnergy;

    [SerializeField] private ParticleSystem ItemsSmokeParticle = default;
    public Gradient gradient;

    public TextMeshProUGUI scoreText;
    public float scoreValue = 0f;

    [Header("Animation")]
    public Animator tobyAnimator;

    public GameObject kalsadaPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tobyAnimator = GetComponent<Animator>();
        rb.useGravity = true;
        playerSpawner = transform.position;
        timeRemaining = maxTime;
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
            timerStamina.fillAmount = timeRemaining / maxTime;
        }

        timerStamina.color = gradient.Evaluate(timerStamina.fillAmount);

        if (timeRemaining <= 0)
        {
            tobyAnimator.SetTrigger("dead");
            EndlessMapForce.instance.enabled = false;
            isGrounded = false;
            PlatformSpawner.instance.canSpawn = false;
            ClonePlayer();
            Invoke("GameOverNa", 3f);
        }

        scoreText.text = ((int)scoreValue).ToString();
        scoreValue += 1f * Time.deltaTime;
    }

    void ClonePlayer()
    {
        // Instantiate the player prefab at a specific position and rotation
        GameObject clone = Instantiate(kalsadaPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        
        // Call the Initialize method on the cloned object
        EndlessMapForce endlessForce = clone.GetComponent<EndlessMapForce>();
        if (endlessForce != null)
        {
            endlessForce.endlessMapSpeed = default; // Call the initialization method
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
        PlayerPrefs.SetInt("playerfinalscore", (int)scoreValue);

        if (scoreValue > PlayerPrefs.GetInt("finalhighscore"))
        {
            PlayerPrefs.SetInt("finalhighscore", (int)scoreValue);
        }

        SceneManager.LoadScene("GameOverTobbyEndless");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            timeRemaining -= minusEnergy;
            Destroy(col.gameObject, 0.3f);
            tobyAnimator.SetTrigger("recoil");
        }
        if (col.gameObject.tag == "ObstacleBelow")
        {
            timeRemaining -= minusEnergy;
            Invoke("SpawnPlayer", 1f);
        }
        if (col.gameObject.tag == "SpeedUp")
        {
            EndlessMapForce.instance.endlessMapSpeed += 10f;
        }
        if (col.gameObject.tag == "SpeedDown")
        {
            EndlessMapForce.instance.endlessMapSpeed -= 10f;
        }
        if (col.gameObject.tag == "Stamina")
        {
            isGrab = true;
        }
    }

    // private void OnTriggerExit(Collider col)
    // {
    //     isGrab = false;
    // }

    void SpawnPlayer()
    {
        transform.position = playerSpawner;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            tobyAnimator.SetTrigger("runn");
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Stamina")
        {
            if (grabRequest)
            {
                timeRemaining += addedEnergy;
                timeRemaining = Mathf.Clamp(timeRemaining, 0, maxTime);
                timerStamina.fillAmount = timeRemaining / maxTime;

                ItemsSmokeParticle.Play();
                Destroy(col.gameObject);
                grabRequest = false;
                isGrab = false;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Stamina")
        {
            isGrab = false;
        }
    }
}
