using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class ScreenShake : MonoBehaviour
{
    [SerializeField] private Transform camera;

    // Desired duration of the shake effect
    [SerializeField] private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    [SerializeField] private float shakeMagnitude = 0.7f;

    // A measure of how quickly the shake effect should evaporate
    [SerializeField] private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;

    void Awake()
    {
        if (transform == null)
        {
            camera = GetComponent(typeof(Transform)) as Transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
        }
    }
    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }
    public void TriggerShake()
    {
        shakeDuration = 2.0f;
    }
}
