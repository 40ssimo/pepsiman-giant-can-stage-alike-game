using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed
    {
        get { return speed; }
        set { speed = value; }
    }
    [SerializeField] private Vector3 spawnPosition;
    private GameObject player;

    void FlattenObject()
    {
        gameObject.transform.localScale = new Vector3(transform.localScale.x, 0.15f, transform.localScale.z);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GiantCan"))
        {
            FlattenObject();
            StartCoroutine(destroyObstacle());
        }
    }

    IEnumerator destroyObstacle()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    public virtual void Act()
    {
        Debug.Log("Do Something");
    }

    public virtual void Spawn()
    {
        
    }
}
