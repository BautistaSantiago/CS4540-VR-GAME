using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [SerializeField] float distanceToCover;
    [SerializeField] float speed;
    [SerializeField] float startDelay;

    private Vector3 startingPosition;
    private bool delayOver = false;
    private bool shouldStartMoving = false;

    void Start()
    {
        startingPosition = transform.position;
        StartCoroutine(StartDelayCoroutine());
    }

    IEnumerator StartDelayCoroutine()
    {
        yield return new WaitForSeconds(startDelay);
        delayOver = true;
        shouldStartMoving = true; // Set to true after delay is over
    }

    void Update()
    {
        if (!delayOver) return; // If delay is not over, do not move

        if (shouldStartMoving) // Check if the delay is over and should start moving
        {
            Vector3 v = startingPosition;
            v.x += distanceToCover * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }
    }
}
