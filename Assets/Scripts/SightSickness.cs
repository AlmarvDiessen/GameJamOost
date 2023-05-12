using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class SightSickness : Disease {
    // Start is called before the first frame update

    private PostProcessVolume volume;
    private Vignette vignette;
    private float intensity = 2f;
    private float speed = 2f;


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
    public override void ApplyEffect() {
        vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup * speed) * intensity;

    }
}
