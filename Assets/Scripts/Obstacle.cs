using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected Vector3 spawnPosition;

    void FlattenObject()
    {
        gameObject.transform.localScale = new Vector3(transform.localScale.x, 0.15f, transform.localScale.z);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GiantCan"))
        {
            FlattenObject();
            StartCoroutine(DestroyObstacle());
        }
    }
    IEnumerator DestroyObstacle()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    public virtual void Spawn()
    {
        Debug.Log(gameObject.name + " spawned");
    }
}
