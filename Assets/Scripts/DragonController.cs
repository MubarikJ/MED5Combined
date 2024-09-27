using System.Collections; // Required for IEnumerator and coroutines
using UnityEngine;

public class DragonController : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5f; // Distance at which the dragon wakes up
    public float attackRange = 3f; // Distance at which the dragon will attack
    public float attackCooldown = 5f; // Time in seconds between attacks
    public float takeOffDelay = 2f; // Delay before TakeOff animation plays

    private Animator animator;
    private bool isAttacking = false;
    private float lastAttackTime = -Mathf.Infinity; // Tracks the time of the last attack
    private bool hasTakenOff = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Sleep"); // Dragon starts by sleeping
        StartCoroutine(StartTakeOffSequence());
    }

    void Update()
    {
        if (!hasTakenOff)
            return; // Only continue once the take-off is complete

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange && !isAttacking && Time.time >= lastAttackTime + attackCooldown)
        {
            FacePlayer(); // Ensure the dragon faces the player before attacking
            StartCoroutine(PerformFlameAttack());
        }
    }

    // Coroutine to handle take-off after a brief sleep
    IEnumerator StartTakeOffSequence()
    {
        yield return new WaitForSeconds(takeOffDelay); // Wait before taking off
        animator.SetTrigger("TakeOff");

        // Wait for the TakeOff animation to complete before starting attacks
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        hasTakenOff = true; // Now dragon can start detecting and attacking
    }

    // Coroutine to handle flame attack animation and cooldown
    IEnumerator PerformFlameAttack()
    {
        isAttacking = true;
        animator.SetTrigger("FlameAttack");

        // Wait for the animation to finish before starting the cooldown
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Start cooldown
        lastAttackTime = Time.time;
        isAttacking = false;
    }

    // Rotate the dragon to face the player
    void FacePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); // Only rotate around y-axis
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // Smooth rotation
    }

    // Optionally, handle when the dragon gets hit or dies
    public void GetHit()
    {
        animator.SetTrigger("GetHit");
    }

    public void Die()
    {
        animator.SetTrigger("Die");
    }
}
