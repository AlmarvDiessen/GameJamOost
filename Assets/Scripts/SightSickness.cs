using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class SightSickness : Disease ,IDeseaseAble {
    // Start is called before the first frame update

    private PostProcessVolume volume;
    private Vignette vignette;
    public float intensity = 2f;
    public float speed = 2f;


    public SightSickness(float pIntensity, float pSpeed) : base() {
        intensity = pIntensity;
        speed = pSpeed;
    }


    void Start() {
        vignette = ScriptableObject.CreateInstance<Vignette>();
        vignette.enabled.Override(true);
        vignette.intensity.Override(1f);

        volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, vignette);

    }

    //override the virutal function to apply the effect in this function.
    public void ApplyEffect() {
        vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup * speed) * intensity;

    }
}
