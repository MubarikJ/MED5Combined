using UnityEngine;

public class FireballDamage : MonoBehaviour
{
    public float damageAmount = 100f; // Damage dealt by the fireball

    void OnCollisionEnter(Collision collision)
    {
        // Check if the fireball collides with the boss
        if (collision.gameObject.CompareTag("Boss"))
        {
            // Get the BossHealth component from the boss
            BossHealth bossHealth = collision.gameObject.GetComponent<BossHealth>();

            if (bossHealth != null)
            {
                // Inflict damage on the boss
                bossHealth.TakeDamage(damageAmount);
            }


        }
        void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Fireball collided with: " + collision.gameObject.name);
        }


    }
}
