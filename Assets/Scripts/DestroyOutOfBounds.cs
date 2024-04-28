using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ZBoundary();
    }

    void ZBoundary()
    {
        if(gameObject.transform.position.z <= -120)
        {
            Destroy(gameObject);
        }
    }
}
