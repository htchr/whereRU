using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    private Vector3 _originalPosition;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _originalPosition = transform.position;
        if (_rb != null)
        {
            _rb.useGravity = false;
        }
    }

    // This method will be called to reset the position and velocity of the WaveObject
    public void Reset()
    {
        transform.position = _originalPosition;
        _rb.velocity = Vector3.zero;
    }
}
