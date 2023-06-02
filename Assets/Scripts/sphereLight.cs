using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR;

public class sphereLight : MonoBehaviour
{
    public GameSettings gameSettings;
    public float[] expandTime; // Time to expand the object in seconds
    public Vector3[] targetScale; // The target scale to expand to
    public Material[] sphereMaterial; // The material to apply to the sphere
    public Shader sphereShader; // The shader to apply to the sphere's material
    public AudioClip[] lazerClips; // Array of lazer audio clips

    public AudioSource handColliderAudioSource;  // AudioSource of the handCollider
    public AudioSource triggerButtonAudioSource; // AudioSource for trigger button sound

    private int i = 0;
    private OVRInput.Controller _leftController = OVRInput.Controller.LTouch;
    private OVRInput.Controller _rightController = OVRInput.Controller.RTouch;

    void Update()
    {
        // check if grip button is pressed on either controller
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, _leftController) || OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, _rightController))
        {
            i = (i + 1) % gameSettings.count;
            handColliderAudioSource.clip = lazerClips[i];  // Set the audio clip of the handCollider's AudioSource to the corresponding lazer clip
            handColliderAudioSource.Play();  // Play the lazer sound
        }

        // Check if the right trigger button is pressed on right controller
        CreateSphere(_rightController);

        // Check if the right trigger button is pressed on left controller
        CreateSphere(_leftController);
    }

    private void CreateSphere(OVRInput.Controller controller)
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            // Create a new Sphere
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            // Position the sphere at the controller's position
            sphere.transform.position = OVRInput.GetLocalControllerPosition(controller);
            // Set the material and shader of the sphere
            Renderer sphereRenderer = sphere.GetComponent<Renderer>();
            sphereRenderer.material = sphereMaterial[i];
            sphereRenderer.material.shader = sphereShader;
            // Disable the Rigidbody component of the sphere
            Rigidbody sphereRigidbody = sphere.GetComponent<Rigidbody>();
            if (sphereRigidbody != null)
            {
                sphereRigidbody.isKinematic = true;
            }
            // Remove the Collider component of the sphere
            Collider sphereCollider = sphere.GetComponent<Collider>();
            if (sphereCollider != null)
            {
                Destroy(sphereCollider);
            }
            // Start the expand coroutine on the sphere
            StartCoroutine(ExpandOverTime(sphere, targetScale[i], expandTime[i]));

            triggerButtonAudioSource.clip = lazerClips[i]; // Set the audio clip of the triggerButtonAudioSource to the corresponding lazer clip
            triggerButtonAudioSource.Play(); // Play the lazer sound for trigger button
        }
    }

    IEnumerator ExpandOverTime(GameObject obj, Vector3 targetScale, float time)
    {
        Vector3 originalScale = obj.transform.localScale;
        Renderer objRenderer = obj.GetComponent<Renderer>();
        float timer = 0;
        while (timer <= time)
        {
            float progress = timer / time;
            obj.transform.localScale = Vector3.Lerp(originalScale, targetScale, progress);
            float ip = Mathf.Lerp(1, 0, progress);
            objRenderer.material.SetFloat("Intersect Power", ip);
            timer += Time.deltaTime;
            yield return null;
        }
        // Ensure the target scale is reached (there might be slight deviations due to frame rates and time)
        obj.transform.localScale = targetScale;
        // Destroy the sphere
        Destroy(obj);
    }

    public AudioClip GetCurrentAudioClip()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, _rightController))
        {
            return lazerClips[i];  // This will return the currently indexed AudioClip for the right controller
        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, _leftController))
        {
            return lazerClips[i];  // This will return the currently indexed AudioClip for the left controller
        }
        else
        {
            return null;
        }
    }
}
