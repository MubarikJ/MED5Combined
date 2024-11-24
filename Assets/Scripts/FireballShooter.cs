using UnityEngine;
using UnityEngine.InputSystem;  // Make sure to use the Input System

public class FireballShooter : MonoBehaviour
{
    public GameObject fireballPrefab;       // Reference to the fireball prefab
    public Transform handTransform;         // Reference to the controller's hand transform
    public float fireballSpeed = 10f;       // Speed of the fireball
    public InputActionReference fireAction; // Reference to the FireS action

    void OnEnable()
    {
        // Enable the fire action
        fireAction.action.Enable();
        fireAction.action.performed += ShootFireball; // Subscribe to the action when it's performed
    }

    void OnDisable()
    {
        // Disable the fire action
        fireAction.action.Disable();
        fireAction.action.performed -= ShootFireball; // Unsubscribe when disabled
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
