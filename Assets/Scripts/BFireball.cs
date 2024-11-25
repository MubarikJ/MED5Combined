using UnityEngine;

public class BFireball : MonoBehaviour
{
    public float speed = 10f; // Speed of the fireball
    private Vector3 targetDirection; // Direction toward the player
    public float lifetime = 10f;

    void Start()
    {
    
        Destroy(gameObject, lifetime);      // Destroy the fireball after a certain time
    }

    public void SetTarget(Vector3 playerPosition)
    {
        // Calculate the direction to the player
        targetDirection = (playerPosition - transform.position).normalized;
        
    }

    void Update()
    {
        // Move the fireball in the target direction
        transform.position += targetDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Handle collision logic (e.g., damaging the player)
        if (other.CompareTag("Player1"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(20); // Adjust damage value as needed
            }
            Destroy(gameObject); // Destroy the fireball
        }


    }
}
