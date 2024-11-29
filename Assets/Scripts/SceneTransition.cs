using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string tagToCheck;        // The tag to look for
    public string targetSceneName;  // The specific scene to transition to
    public float checkInterval = 5f; // Time interval to check for the tag

    private void Start()
    {
        // Start checking for the tag at regular intervals
        InvokeRepeating(nameof(CheckForTag), 0f, checkInterval);
    }

    private void CheckForTag()
    {
        // Find any object with the specified tag
        GameObject taggedObject = GameObject.FindWithTag(tagToCheck);

        if (taggedObject != null)
        {
            Debug.Log($"Object with tag '{tagToCheck}' found! Transitioning to scene '{targetSceneName}'...");
            LoadTargetScene();
        }
    }

    private void LoadTargetScene()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            if (SceneManager.GetSceneByName(targetSceneName) != null)
            {
                SceneManager.LoadScene(targetSceneName); // Load the specified scene
            }
            else
            {
                Debug.LogError($"Scene '{targetSceneName}' not found in Build Settings!");
            }
        }
        else
        {
            Debug.LogError("Target scene name is not set!");
        }
    }
}
