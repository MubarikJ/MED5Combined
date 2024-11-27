using UnityEngine;

public class BossFireballAttack : MonoBehaviour
{
    public GameObject fireballPrefab;    // Fireball prefab to spawn
    public Transform fireballSpawnPoint; // Where the fireball spawns (e.g., dragon's mouth)
    public float fireballSpeed = 15f;   // Speed of the fireball
    public float fireballCooldown = 3f; // Time between fireball attacks
    public Transform player;            // Reference to the player's Transform
    public float attackRange = 20f;     // Distance within which the boss can attack

    private float nextFireTime = 5f;

    void Update()
    {
        // Check if the player is within range
        if (player != null && Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            // Check if it's time to fire
            if (Time.time >= nextFireTime)
            {
                ShootFireball(); // Call the shooting logic
                nextFireTime = Time.time + fireballCooldown;
            }
        }
    }

    private void ShootFireball()
    {
        // Ensure fireballPrefab, fireballSpawnPoint, and player are assigned
        if (fireballPrefab != null && fireballSpawnPoint != null && player != null)
        {
            // Instantiate the fireball
            GameObject Bfireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);

            // Get the Fireball script and set its target
            BFireball BfireballScript = Bfireball.GetComponent<BFireball>();
            if (BfireballScript != null)
            {
                BfireballScript.SetTarget(player.position); // Set the target as the player's position
            }

            Debug.Log("Dragon shot a targeted fireball!");
        }
    }

    // Optional: Add a spread shot mechanic
    private void ShootSpreadFireball()
    {
        // Fire a spread of fireballs
        for (int i = -2; i <= 2; i++) // Adjust the range for more/less spread
        {
            GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
            Rigidbody rb = fireball.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Slightly adjust the direction for each fireball
                Vector3 direction = Quaternion.Euler(0, i * 40, 0) * fireballSpawnPoint.forward;
                rb.velocity = direction * fireballSpeed;
            }
        }

        Debug.Log("Dragon fired a spread of fireballs!");
    }
}
