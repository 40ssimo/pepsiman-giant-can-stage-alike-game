using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCar : Obstacle
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
    }

    public override void Spawn()
    {
        base.Spawn();

        var player = GameObject.FindGameObjectWithTag("Player");
        Vector3 spawnPosition = new Vector3(player.gameObject.transform.position.x, 0, 40f);

        Instantiate(gameObject, spawnPosition, gameObject.transform.rotation);
    }

}
