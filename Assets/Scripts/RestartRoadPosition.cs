using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartRoadPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReplaceRoad();
    }

    void ReplaceRoad()
    {
        if (gameObject.transform.position.z <= -120f)
        {
            gameObject.transform.position = new Vector3(0, 0, 280f);
        }
    }
}
