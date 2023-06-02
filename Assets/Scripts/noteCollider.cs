using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class noteCollider : MonoBehaviour
{
    public GameSettings gameSettings;
    public GameObject[] objectsToDeactivate;
    public TextMeshProUGUI textElement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in objectsToDeactivate)
            {
                obj.SetActive(false);
            }
            gameSettings.count += 1;
            textElement.text = gameSettings.count.ToString() + textElement.text.Substring(1);
        }
    }
}