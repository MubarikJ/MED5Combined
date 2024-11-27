using UnityEngine;
using UnityEngine.SceneManagement; // Import for scene management

public class SceneManagerOnBossDeath : MonoBehaviour
{
    public string sceneToLoad; // The scene to load if no Boss object is found

    void Update()
    {
        // Check if there's an object with the "Boss" tag
        if (GameObject.FindGameObjectWithTag("Boss") == null)
        {
            // If no "Boss" object is found, load the specified scene
            LoadScene();
        }
    }

    // Method to load the specified scene
    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
