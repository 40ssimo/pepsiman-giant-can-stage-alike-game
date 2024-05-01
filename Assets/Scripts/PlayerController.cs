using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float horizontalSpeed = 50f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private float gravityModifier = 2f;
    [SerializeField] private bool hasPowerup;
    private bool doLastMoment = false;

    private Animator animator;

    public ParticleSystem explosionSmoke;
    public GameObject powerup;

    private GameManager gameManager;
    private AudioManager audioManager;

    private AudioSource audioSource;

    
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        audioSource = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;
        hasPowerup = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            MoveHorizontally();
            Jump();
            SpinPowerup(hasPowerup);
        }

        CheckPlayerLives();
    }

    void MoveHorizontally()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        transform.position += Vector3.left * horizontalInput * horizontalSpeed * Time.deltaTime;

        checkHorizontalBoundary();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            audioManager.PlaySound(audioSource, audioManager.audioList[0]);
        }
    }

    void checkHorizontalBoundary()
    {
        if (transform.position.x <= -9)
        {
            transform.position = new Vector3(-9f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 9)
        {
            transform.position = new Vector3(9f, transform.position.y, transform.position.z);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            isGrounded = true;
        }
        
        if (hasPowerup)
        {
            HitObstacleWithPowerup(collision);
        } else
        {
            HitObstacle(collision);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PickPowerup(other);
    }

    void HitObstacle(Collision collision)
    {
        //if hit obstacle decrease lives and destroy the obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.lives -= 1;
            explosionSmoke.Play();
            Destroy(collision.gameObject);

            if (gameManager.lives >= 1)
            {
                audioManager.PlaySound(audioSource, audioManager.audioList[1]);
                Debug.Log("Player got hit");
            }
        }
    }

    void HitObstacleWithPowerup(Collision collision)
    {
        //if hit obstacle decrease lives and destroy the obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            explosionSmoke.Play();
            audioManager.PlaySound(audioSource, audioManager.audioList[1]);
            Destroy(collision.gameObject);

        }
    }

    private void PickPowerup(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup Pickup"))
        {
            powerup.SetActive(true);
            hasPowerup = true;

            Destroy(other.gameObject);
            audioManager.PlaySound(audioSource, audioManager.audioList[3]);
            StartCoroutine(SetoffPowerup());
        }
    }

    private void SpinPowerup(bool hasPowerup)
    {
        if (hasPowerup)
        {
            powerup.transform.Rotate(0, 200f * Time.deltaTime, 0);
        }
    }

    IEnumerator SetoffPowerup()
    {
        yield return new WaitForSeconds(5);
        powerup.SetActive(false);
        audioManager.PlaySound(audioSource, audioManager.audioList[4]);
        hasPowerup = false;
    }

    public void CheckPlayerLives()
    {
        if (gameManager.gameOver && !doLastMoment)
        {
            // player death
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 2);
            audioManager.PlaySound(audioSource, audioManager.audioList[1]);
            audioManager.PlaySound(audioSource, audioManager.audioList[2]);
            Debug.Log("Player death");
            doLastMoment = true;
        }
    }
}
