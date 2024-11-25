using UnityEngine;
using System.Collections;

public class DragonAttack : MonoBehaviour
{
    public GameObject fireballPrefab; // Fireball prefab to instantiate
    public Transform fireballSpawnPoint; // Point from which fireballs are shot
    public Transform player; // Reference to the player
    public float attackRange = 15f; // Range within which the dragon can attack
    public int maxFireballs = 6; // Maximum number of fireballs the dragon can shoot
    public float baseReloadTime = 2f; // Base reload time
    public float additionalReloadTimePerBall = 0.5f; // Additional reload time per extra ball

    private bool isAttacking = false;

    void Update()
    {
        // Check if the player is within attack range
        if (Vector3.Distance(transform.position, player.position) <= attackRange && !isAttacking)
        {
            StartCoroutine(AttackPlayer());
        }
    }

    private IEnumerator AttackPlayer()
    {
        isAttacking = true;

        // Randomize the number of fireballs (at least 1, up to maxFireballs)
        int fireballsToShoot = Random.Range(1, maxFireballs + 1);
        Debug.Log("Dragon will shoot " + fireballsToShoot + " fireballs.");

        // Shoot the fireballs one by one
        for (int i = 0; i < fireballsToShoot; i++)
        {
            ShootFireball();
            yield return new WaitForSeconds(0.5f); // Short delay between fireballs
        }

        // Calculate reload time based on the number of fireballs shot
        float reloadTime = baseReloadTime + (fireballsToShoot - 1) * additionalReloadTimePerBall;
        Debug.Log("Dragon reload time: " + reloadTime + " seconds.");
        yield return new WaitForSeconds(reloadTime);

        isAttacking = false;
    }

    private void ShootFireball()
    {
        if (fireballPrefab != null && fireballSpawnPoint != null)
        {
            Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
            Debug.Log("Dragon shot a fireball!");
        }
    }
}
