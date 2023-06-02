using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwapReset : MonoBehaviour
{
    public GameSettings gameSettings;
    public string sceneName; // Name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object is the player
        {
            gameSettings.count = 0;
            SceneManager.LoadScene(sceneName); // Load the new scene
        }
    }
}
