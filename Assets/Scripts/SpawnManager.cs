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
    void Start()
    {
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
        fence.GetComponent<Fence>().Spawn();
    }

    void SpawnTricone()
    {
        tricone.GetComponent<Cone>().Spawn();
    }

    void SpawnGreenCar()
    {
        greenCar.GetComponent<GreenCar>().Spawn();
    }

    void SpawnBlueCar()
    {
        blueCar.GetComponent<BlueCar>().Spawn();
    }

    void SpawnPowerup()
    {
        powerup.GetComponent<Powerup>().Spawn();
    }
}
