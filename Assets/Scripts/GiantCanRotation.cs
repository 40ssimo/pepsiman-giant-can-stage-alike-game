using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantCanRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float rotationSpeed = -250f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
