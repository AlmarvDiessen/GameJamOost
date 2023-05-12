using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SightBlur : MonoBehaviour
{
    private PostProcessVolume volume;
    private ChromaticAberration Chromatic;
    private float intensity = 2f;
    private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.TryGetComponent<ChromaticAberration>(out Chromatic);
    }

    public void ApplyEffect()
    {
        Chromatic.intensity.value = Mathf.Sin(Time.realtimeSinceStartup * speed) * intensity;

    }
}
