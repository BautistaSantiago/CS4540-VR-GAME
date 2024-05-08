using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Throwing : MonoBehaviour
{
    List<Vector3> trackingPos = new List<Vector3>();
    public float velocity = 1000f;

    bool pickedUp = false;
    GameObject parentHand;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (pickedUp)
        {
            rb.useGravity = false;

            transform.position = parentHand.transform.position;
            transform.rotation = parentHand.transform.rotation;

            if (trackingPos.Count > 15)
            {
                trackingPos.RemoveAt(0);
            }
            trackingPos.Add(transform.position);

            // Check for release of trigger button
            if (Input.GetAxis("RightTrigger") < 0.1f)
            {
                pickedUp = false;
                Vector3 direction = trackingPos[trackingPos.Count - 1] - trackingPos[0];
                rb.AddForce(direction * velocity);
                rb.useGravity = true;
                rb.isKinematic = false;
                GetComponent<Collider>().isTrigger = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for collision with hand and trigger button pressed
        if (other.gameObject.tag == "hand" && Input.GetAxis("RightTrigger") > 0.9f)
        {
            pickedUp = true;
            parentHand = other.gameObject;
        }
    }
}