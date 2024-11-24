using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health of the boss
    private float currentHealth;

    void Start()
    {
        // Initialize the boss's health
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Reduce health
        currentHealth -= damage;
        Debug.Log("Boss took damage! Current health: " + currentHealth);

        // Check if health is 0 or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Boss is dead!");
        // Add any death animations or effects here

        // Destroy the boss GameObject
        Destroy(gameObject);
    }
}
