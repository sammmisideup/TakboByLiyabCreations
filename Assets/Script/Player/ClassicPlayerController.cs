using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassicPlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public Rigidbody rb;
    public float jumpForce;
    private float jumpDown = 80f;
    public bool isGrounded = false;

    [Header("Player Health")]
    public Vector3 playerSpawner;
    public GameObject heart1, heart2, heart3;
    public static int health;

    [Header("Star System")]
    public StarManager starManager;  // Reference to StarManager to update the star count
    public CollectibleManager collectibleManager;  // Reference to CollectibleManager for item collection
    private bool hasCollectedStar = false;

    [SerializeField] private ParticleSystem ItemsSmokeParticle = default;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        playerSpawner = transform.position;

        // Initialize health system
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
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
                Invoke("GameOverNa", 0.5f);
                break;
        }
    }

    public void GameOverNa()
    {
        SceneManager.LoadScene("TobbyGameOver");
    }

    public void Winner()
    {
        starManager.CollectStar();  // Award the third star
        PlayerPrefs.SetInt("TotalStars", starManager.totalStars);  // Save the star count
        SceneManager.LoadScene("WinningScene");  // Load the Winning Scene
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            health -= 1;
            Destroy(col.gameObject, 0.2f);
        }

        if (col.gameObject.tag == "ObstacleBelow")
        {
            health -= 1;
            Invoke("SpawnPlayer", 1f);
        }

        // Check for star collection
        if (col.gameObject.CompareTag("Star") && !hasCollectedStar)
        {
            hasCollectedStar = true;
            starManager.CollectStar();  // Collect first star
            Destroy(col.gameObject);   // Destroy the star object
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "SafeZone")
        {
            Debug.Log("SafeZone Reached! Collecting Third Star...");
            Invoke("Winner", 0.3f);  // Trigger the Winner logic when reaching SafeZone
        }
    }
    

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Collectibles")
        {
            if (Input.GetKeyDown(KeyCode.G))  // Press G to collect item
            {
                ItemsSmokeParticle.Play();
                collectibleManager.CollectItem(col.gameObject);
            }
        }
    }

    void SpawnPlayer()
    {
        transform.position = playerSpawner;
    }
}
