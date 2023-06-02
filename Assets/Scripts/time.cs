using UnityEngine;
using TMPro;

public class time : MonoBehaviour
{
    public GameSettings gameSettings;
    public TextMeshProUGUI textMesh;

    void Start()
    {
        int minutes = Mathf.FloorToInt(gameSettings.time / 60F);
        int seconds = Mathf.FloorToInt(gameSettings.time - minutes * 60);
        textMesh.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
