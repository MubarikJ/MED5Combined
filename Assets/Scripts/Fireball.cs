using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;               // Speed of the fireball
    public float maxDistance = 50f;         // Maximum distance before fireball disappears
    public float lifetime = 5f;             // Time before fireball disappears
    private Vector3 startPosition;          // Initial position to track the distance

    void Start()
    {
        startPosition = transform.position; // Record the start position
        Destroy(gameObject, lifetime);      // Destroy the fireball after a certain time
    }

    void Update()
    {
        // Move the fireball forward based on its current direction
        transform.position += transform.forward * speed * Time.deltaTime;

        // Check if the fireball has traveled the max distance and destroy it
        if (Vector3.Distance(startPosition, transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }
    }

}
