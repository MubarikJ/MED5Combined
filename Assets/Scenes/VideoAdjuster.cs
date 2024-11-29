using UnityEngine;

public class VideoAdjuster : MonoBehaviour
{
    public Transform vrCamera;   // Reference to the VR camera
    public Transform videoDisplay; // Reference to the video display object
    public float distance = 5f;  // Desired distance from the VR camera

    void Start()
    {
        if (vrCamera != null && videoDisplay != null)
        {
            // Position the video display in front of the VR camera
            Vector3 direction = vrCamera.forward; // Get the forward direction of the camera
            Vector3 targetPosition = vrCamera.position + direction * distance; // Calculate the target position
            videoDisplay.position = targetPosition;

            // Align the video display to face the camera
            videoDisplay.LookAt(vrCamera);
            videoDisplay.Rotate(0, 180, 0); // Rotate to face the player correctly
        }
        else
        {
            Debug.LogError("VR Camera or Video Display is not assigned!");
        }
    }
}
