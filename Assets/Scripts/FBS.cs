using UnityEngine;
using UnityEngine.InputSystem;  // Make sure you're using the Input System

public class FBS : MonoBehaviour
{
    public GameObject fireballPrefab;   // Reference to the fireball prefab
    public Transform handTransform;     // Reference to the controller's hand transform
    public float fireballSpeed = 10f;   // Speed of the fireball
    public InputActionReference fireAction; // Input Action for firing

    void OnEnable()
    {
        // Enable the fire input action
        fireAction.action.Enable();
        fireAction.action.performed += ShootFireball;
    }

    void OnDisable()
    {
        // Disable the fire input action
        fireAction.action.Disable();
        fireAction.action.performed -= ShootFireball;
    }

    void ShootFireball(InputAction.CallbackContext context)
    {
        // Instantiate the fireball at the hand's position and rotation
        GameObject fireball = Instantiate(fireballPrefab, handTransform.position, handTransform.rotation);

        // Get the fireball's Rigidbody and apply velocity in the hand's forward direction
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.velocity = handTransform.forward * fireballSpeed;
    }
}
