using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStuck : MonoBehaviour
{
    // Layer mask for objects the VR object can stick to
    public LayerMask stickyLayerMask;

    // Flag to check if the VR object is currently stuck
    private bool isStuck = false;

    // Reference to the object it's currently stuck to
    private GameObject stuckObject;

    // Function called when collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        // Check if collided with another object and not already stuck
        if (!isStuck && IsStickySurface(collision.gameObject))
        {
            // Set flag to indicate it's stuck
            isStuck = true;

            // Store the reference to the object it's stuck to
            stuckObject = collision.gameObject;

            // Make the VR object a child of the object it's stuck to
            transform.SetParent(stuckObject.transform);

            // Disable the Rigidbody to prevent further physics interactions
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Function to check if a collided object is a sticky surface
    private bool IsStickySurface(GameObject obj)
    {
        // Check if the collided object is in the sticky layer mask
        return (stickyLayerMask & (1 << obj.layer)) != 0;
    }
}
