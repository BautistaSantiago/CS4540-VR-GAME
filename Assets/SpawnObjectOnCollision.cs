using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine;

public class SpawnObjectOnCollision : MonoBehaviour
{
    // Reference to the object to spawn
    public GameObject objectToSpawn;

    // Reference to the spawn point
    public Transform spawnPoint;

    // Method to spawn the object
    public void Spawn()
    {
        // Check if the object to spawn and spawn point are assigned
        if (objectToSpawn != null && spawnPoint != null)
        {
            // Instantiate the object at the position of the spawn point
            Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Object to spawn or spawn point not assigned.");
        }
    }

    // This method is called when a collision is detected
    private void OnCollisionEnter(Collision collision)
    {
        // Spawn the object when collision is detected
        Spawn();
    }
}