using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : Obstacle
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void Spawn()
    {
        base.Spawn();

        var spawnPositionLeft = new Vector3(5, 0, 15f);
        var spawnPositionMid = new Vector3(0, 0, 15f);
        var spawnPositionRight = new Vector3(-5, 0, 15f);

        List<Vector3> spawnPositionList = new List<Vector3> { spawnPositionRight, spawnPositionLeft, spawnPositionMid };
        var index = Random.Range(0, spawnPositionList.Count);

        Instantiate(gameObject, spawnPositionList[index], gameObject.transform.rotation);
    }
}
