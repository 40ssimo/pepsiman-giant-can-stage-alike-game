using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float horizontalSpeed = 50f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private float gravityModifier = 2f;
    public int lives = 3;

    private Animator jumpAnimator;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        jumpAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontally();
        Jump();
        
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
        
        HitObstacle(collision);
    }

    void HitObstacle(Collision collision)
    {
        //if hit obstacle decrease lives and destroy the obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            lives -= 1;
            Destroy(collision.gameObject);

        }
    }
}
