using UnityEngine;
using TMPro;

public class NoteController : MonoBehaviour
{
    private AudioSource audioSource;
    private int stopCount = 0; // Used to record the number of times to stop playing audio

    //[SerializeField]
    //private TextMeshProUGUI stopCountText; // Reference to the Text UI component

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OculusController")  // Suppose your Oculus controller has a label "OculusController"
        {
            if (audioSource.isPlaying) 
            {
                audioSource.Stop();
                //stopCount++; // Increase the number of times to stop playing audio
                //stopCountText.text = "Numbers of notes: " + stopCount; // Update the text in the UI
            } 
            else 
            {
                audioSource.Play();
            }
        }
    }
}
