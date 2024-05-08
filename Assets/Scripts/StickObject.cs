using UnityEngine;

public class StickObject : MonoBehaviour
{
    // The object to stick to
    public GameObject militaryTarget;

    // Whether the object is currently sticking to the target
    private bool isSticking = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the target
        if (collision.gameObject == militaryTarget)
        {
            // Stick to the target
            isSticking = true;

            // Parent this object to the target so it moves with it
            transform.parent = militaryTarget.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // If the colliding object was the target and we were sticking to it
        if (collision.gameObject == militaryTarget && isSticking)
        {
            // Stop sticking to the target
            isSticking = false;

            // Unparent this object so it doesn't move with the target anymore
            transform.parent = null;
        }
    }
}
