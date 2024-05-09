using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine;

public class CollisionSound4 : MonoBehaviour
{
    public AudioClip collisionSound; // Sound to play on collision

    public GameObject ScoreManager;

    private AudioSource audioSource;

    private ScoreManager sManager;
    void Start()
    {
        // Add an AudioSource component to the object
        audioSource = gameObject.AddComponent<AudioSource>();
        sManager = ScoreManager.GetComponent<ScoreManager>();
        // Assign the collision sound to the AudioSource
        audioSource.clip = collisionSound;
    }

    void Awake()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a Rigidbody
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            // Play the collision sound
            sManager.IncreaseScore(4);
            audioSource.Play();
            // Debug.Log(score.playerScore);
        }

    }
}