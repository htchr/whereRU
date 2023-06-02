using UnityEngine;
using TMPro;

public class count : MonoBehaviour
{
    public GameSettings gameSettings;
    public TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh.text = gameSettings.count.ToString() + textMesh.text.Substring(1);
    }
}
