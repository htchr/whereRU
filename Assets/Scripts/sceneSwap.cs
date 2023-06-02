using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwap : MonoBehaviour
{
    public string sceneName; // Name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object is the player
        {
            SceneManager.LoadScene(sceneName); // Load the new scene
        }
    }
}
