using UnityEngine;

public class BossFireball : MonoBehaviour
{
    public int damageAmount = 20; // Damage dealt to the player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // Apply damage
            }

            Destroy(gameObject); // Destroy fireball to prevent multiple damage events
        }
        else
        {
            Destroy(gameObject); // Optional: Destroy fireball on other collisions
        }
    }


}
