using UnityEngine;
using UnityEngine.XR;

public class Controller_R : MonoBehaviour
{
    [Header("Audio Clip")]
    [SerializeField] AudioClip _audioClip;

    [Header("Audio Source")]
    [SerializeField] AudioSource _audioSource;

    [Header("Wave Object")]
    [SerializeField] GameObject _waveObject;

    [Header("Wave Speed")]
    [SerializeField] float _waveSpeed = 10.0f;

    [Header("Right Hand Controller")]
    [SerializeField] Transform _rightHandController;  // Reference to the right hand controller

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
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)) // specify the right hand controller
        {
            PlaySound();
            _waveObject.SetActive(true);
            _waveRigidbody.velocity = _rightHandController.transform.forward * _waveSpeed;  // set the firing direction as the pointing direction of the right hand controller
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
