using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//THIS HAS BOTH THE COLLISION SOUND AND FOR POINT ON THE SCORE BOARD
//EVERY OTHER SCRIPT OF THIS LIKE COLLISIONSOUND2 JUST CHANGES THE POINT VALUE FOR OTHER TARGETS
public class CollisionSound : MonoBehaviour
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
            sManager.IncreaseScore(1); // Adjust this for score value
            audioSource.Play();
            // Debug.Log(score.playerScore);
        }

    }
}