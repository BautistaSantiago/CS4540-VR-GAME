using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSpawn : MonoBehaviour
{
    public string targetObjectName; // The name of the GameObject to detect collisions with
    public GameObject objectToSpawn; // The object to spawn upon collision

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the specified object name
        if (collision.gameObject.name == targetObjectName)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        // Check if the object to spawn is assigned
        if (objectToSpawn != null)
        {
            // Spawn the object at the same position as this object
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Object to spawn is not assigned!");
        }
    }
}