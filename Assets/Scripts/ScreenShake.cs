using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class ScreenShake : MonoBehaviour {


    // Desired duration of the shake effect
    [SerializeField] private float shakeDuration = 1f;

    // A measure of magnitude for the shake. Tweak based on your preference
    [SerializeField] private float shakeMagnitude = 0.02f;

    // A measure of how quickly the shake effect should evaporate
    [SerializeField] private float dampingSpeed = 1.0f;
    public float shakeInterval;


    void Awake() {

    }

    // Start is called before the first frame update
    void Start() {
        shakeInterval = 4f;
        shakeMagnitude = 0.02f;
    }

    // Update is called once per frame
    void Update() {
        do {
            if (shakeDuration >= 0) {
                transform.localPosition = transform.localPosition + Random.insideUnitSphere * shakeMagnitude;
            }
            shakeDuration -= Time.deltaTime * dampingSpeed;
            shakeInterval -= Time.deltaTime * dampingSpeed;

        } while (shakeDuration >= 0 && shakeInterval <= 0);

        if (shakeInterval <= 0 && shakeDuration < 0) {
            shakeDuration = 1f;
            shakeInterval = 4f;
        }
    }
    public void TriggerShake() {
        shakeDuration = 1.0f;
    }
}
