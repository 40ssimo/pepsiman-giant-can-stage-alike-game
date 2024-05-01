using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveBackward : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 5f;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            Move();
        }

        if (gameManager.gameOver && (gameObject.tag == "GiantCan"))
        {
            Move();
        }
    }

    void Move()
    {
        transform.position -= Vector3.forward * Time.deltaTime * speed;
    }
}
