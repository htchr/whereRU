using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public GameSettings gameSettings;
    public TextMeshProUGUI textMesh;

    void Update()
    {
        // Increase the timer by the time since the last frame
        gameSettings.time += Time.deltaTime;

        // Convert the time to integer seconds and minutes
        int minutes = Mathf.FloorToInt(gameSettings.time / 60F);
        int seconds = Mathf.FloorToInt(gameSettings.time - minutes * 60);

        // Update the text mesh
        textMesh.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
