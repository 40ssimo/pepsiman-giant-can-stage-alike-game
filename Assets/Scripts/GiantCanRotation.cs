using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantCanRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float rotationSpeed = -250f;
    private GameManager gameManager;
    private MoveBackward moveBackward;
    private AudioManager audioManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        moveBackward = GetComponent<MoveBackward>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!gameManager.gameOver)
        {
            RotateCan();
        } else
        {
            RotateCan();
            moveBackward.enabled = true;
        }
    }

    void RotateCan()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
