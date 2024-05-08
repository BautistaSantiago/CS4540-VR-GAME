using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    // Adjust this value to control the throw force
    public float throwForce = 10f;

    // Boolean to check if the object is currently being held
    private bool isBeingHeld = false;

    // Rigidbody component of the object
    private Rigidbody rb;

    // Position of the object before it's thrown
    private Vector3 originalPosition;

    // Quaternion of the object before it's thrown
    private Quaternion originalRotation;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the object is being held
        if (isBeingHeld)
        {
            // Move the object to the mouse position
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10; // Distance from the camera to the object
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }

        // Check for input to throw the object
        if (isBeingHeld && Input.GetMouseButtonUp(0))
        {
            ThrowObject();
        }
    }

    void OnMouseDown()
    {
        // Set the object to be held
        isBeingHeld = true;

        // Store the original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // Disable gravity while being held
        rb.useGravity = false;
    }

    void OnMouseUp()
    {
        // Release the object
        isBeingHeld = false;

        // Enable gravity again
        rb.useGravity = true;
    }

    void ThrowObject()
    {
        // Calculate the direction to throw the object
        Vector3 throwDirection = transform.position - originalPosition;

        // Reset the object's position and rotation to prevent weird behavior
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        // Apply the throw force
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // Reset the boolean
        isBeingHeld = false;

        // Enable gravity again
        rb.useGravity = true;
    }
}
