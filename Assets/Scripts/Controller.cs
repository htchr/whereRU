using UnityEngine;
using UnityEngine.XR;

public class Controller : MonoBehaviour
{
    [Header("Audio Clip")]
    [SerializeField] AudioClip _audioClip;

    [Header("Audio Source")]
    [SerializeField] AudioSource _audioSource;

    [Header("Wave Object")]
    [SerializeField] GameObject _waveObject;

    [Header("Wave Speed")]
    [SerializeField] float _waveSpeed = 10.0f;

    [Header("Left Hand Controller")]
    [SerializeField] Transform _leftHandController;  // Reference to the left hand controller

    private Rigidbody _waveRigidbody;
    private WaveMovement _waveMovement;  // Reference to the WaveMovement script

    private void Start()
    {
        _waveRigidbody = _waveObject.GetComponent<Rigidbody>();
        _waveMovement = _waveObject.GetComponent<WaveMovement>();  // Get the WaveMovement script
        _waveObject.SetActive(false);  // make sure the WaveObject is inactive at the start
    }

    private void Update()
    {
        // Replace the key check with a check for the Oculus trigger
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch)) // specify the left hand controller
        {
            PlaySound();
            _waveObject.SetActive(true);
            _waveRigidbody.velocity = _leftHandController.transform.forward * _waveSpeed;  // set the firing direction as the pointing direction of the left hand controller
        }
    }

    public void PlaySound()
    {
        _audioSource.PlayOneShot(_audioClip);
    }

    public void StopSound()
    {
        _audioSource.Stop();
    }

    // Call this method to reset the position of the WaveObject
    public void ResetWaveObject()
    {
        _waveMovement.Reset();
    }
}
