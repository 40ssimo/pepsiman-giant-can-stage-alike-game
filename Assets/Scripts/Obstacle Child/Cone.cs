using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cone : Obstacle
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckChildren();
    }

    public override void Spawn()
    {
        Vector3 spawnPositionRight = new Vector3(-5.5f, 0, 28f);
        Vector3 spawnPositionLeft = new Vector3(5.5f, 0, 28f);

        List<Vector3> spawnPositionList = new List<Vector3> { spawnPositionRight, spawnPositionLeft };
        var index = Random.Range(0, spawnPositionList.Count);

        Instantiate(gameObject, spawnPositionList[index], gameObject.transform.rotation);
        Debug.Log(gameObject.name + " spawned");
    }

    void CheckChildren()
    {
        if (gameObject.transform.childCount == 0 && gameObject.name.StartsWith("Tricone"))
        {
            Destroy(gameObject);
        }
    }
}
