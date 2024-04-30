using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCar : Obstacle
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

        var spawnPosition1 = new Vector3 (8, 0, 35);
        var spawnPosition2 = new Vector3 (-8, 0, 35);

        List<Vector3> spawnPositionList = new List<Vector3>() {spawnPosition1, spawnPosition2};
        var index = Random.Range(0, spawnPositionList.Count);

        Instantiate(gameObject, spawnPositionList[index], gameObject.transform.rotation);
    }
}
