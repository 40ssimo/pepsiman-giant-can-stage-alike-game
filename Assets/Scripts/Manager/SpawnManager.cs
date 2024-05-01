using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fence;
    public GameObject tricone;
    public GameObject greenCar;
    public GameObject blueCar;
    public GameObject powerup;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        InvokeRepeating("SpawnFence", 0f, Random.Range(1f, 2.15f));
        InvokeRepeating("SpawnTricone", 0.5f, Random.Range(1f, 3.15f));
        InvokeRepeating("SpawnBlueCar", 2f, Random.Range(3f, 5.15f));
        InvokeRepeating("SpawnGreenCar", 0f, Random.Range(2f, 3f));
        InvokeRepeating("SpawnPowerup", 0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnFence()
    {
        if (!gameManager.gameOver)
        {
            fence.GetComponent<Fence>().Spawn();
        }
    }

    void SpawnTricone()
    {
        if (!gameManager.gameOver)
        {
            tricone.GetComponent<Cone>().Spawn();
        }
    }

    void SpawnGreenCar()
    {
        if (!gameManager.gameOver)
        {
            greenCar.GetComponent<GreenCar>().Spawn();
        }
    }

    void SpawnBlueCar()
    {
        if (!gameManager.gameOver)
        {
            blueCar.GetComponent<BlueCar>().Spawn();
        }
    }

    void SpawnPowerup()
    {
        if (!gameManager.gameOver)
        {
            powerup.GetComponent<Powerup>().Spawn();
        }
    }
}
