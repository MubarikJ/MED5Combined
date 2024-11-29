using UnityEngine;

public class BossLookAtPlayer : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float rotationSpeed = 5f;  // Speed of the rotation

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction to the player
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // Keep the rotation horizontal

            // If the direction is significant, rotate towards the player
            if (direction.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
