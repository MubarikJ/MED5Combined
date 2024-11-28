using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Initialize health
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Player is already dead! No further damage applied.");
            return; // Stop further damage processing
        }

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Ensure health does not drop below 0

        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        StartCoroutine(RestartSceneAfterDelay(8.0f)); // Delay of 2 seconds
    }

    private IEnumerator RestartSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified time
        RestartScene();
    }

    private void RestartScene()
    {
        string BlackSmith = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(BlackSmith);
    }
}
