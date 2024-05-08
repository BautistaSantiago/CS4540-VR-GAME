using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioClip collisionSound; // Sound to play on collision

    public GameObject ScoreManager;

    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component to the object
        audioSource = gameObject.AddComponent<AudioSource>();
        // Assign the collision sound to the AudioSource
        audioSource.clip = collisionSound;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a Rigidbody
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            // Play the collision sound
            audioSource.Play();
        }
    }
}