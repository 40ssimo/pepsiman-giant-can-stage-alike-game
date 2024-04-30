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
    public int lives = 3;

    private Animator jumpAnimator;

    public ParticleSystem explosionSmoke;
    public GameObject powerup;

    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        jumpAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        hasPowerup = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontally();
        Jump();
        
        if (hasPowerup)
        {
            powerup.transform.Rotate(0, 200f * Time.deltaTime, 0);
        }
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
            jumpAnimator.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
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
            lives -= 1;
            explosionSmoke.Play();
            Destroy(collision.gameObject);

        }
    }

    void HitObstacleWithPowerup(Collision collision)
    {
        //if hit obstacle decrease lives and destroy the obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            explosionSmoke.Play();
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
            StartCoroutine(SetoffPowerup());

        }
    }

    IEnumerator SetoffPowerup()
    {
        yield return new WaitForSeconds(5);
        powerup.SetActive(false);
        hasPowerup = false;
    }
}
