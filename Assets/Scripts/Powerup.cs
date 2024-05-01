using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        var spawnPosition1 = new Vector3(5f, 1.5f, 100f);
        var spawnPosition2 = new Vector3(-5f, 1.5f, 100f);
        var spawnPosition3 = new Vector3(0, 1.5f, 100f);

        List<Vector3> spawnPositionList = new List<Vector3>() { spawnPosition1, spawnPosition2, spawnPosition3};
        var index = Random.Range(0, spawnPositionList.Count);

        Instantiate(gameObject, spawnPositionList[index], gameObject.transform.rotation);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GiantCan"))
        {
            Destroy(gameObject);
        }
    }
}
