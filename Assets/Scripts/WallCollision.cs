using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour
{
    private AudioSource _audioSource;
    public sphereLight _sphereLight;  // Reference to the sphereLight script

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RightControllerSphere") || collision.gameObject.CompareTag("LeftControllerSphere"))
        {
            _audioSource.clip = _sphereLight.GetCurrentAudioClip();  // Set the AudioSource clip to the current audio clip from the sphereLight script
            StartCoroutine(PlaySoundWithDelay(0.5f)); // Add a delay

            var rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
            }
        }
    }

    private IEnumerator PlaySoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _audioSource.Play();
    }
}
