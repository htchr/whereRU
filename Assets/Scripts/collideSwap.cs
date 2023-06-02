using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collideSwap : MonoBehaviour
{
    public GameObject[] objectsToDeactivate;
    public GameObject[] objectsToActivate;
    public TextMeshProUGUI textElement;
    public string text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in objectsToDeactivate)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
            if (text != null)
                { textElement.text = text; }
        }
    }
}