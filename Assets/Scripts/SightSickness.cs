using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class SightSickness : Disease
{
    // Start is called before the first frame update
   
    private PostProcessVolume volume;
    private Vignette vignette;
    private float intensity = 2f;
    private float speed = 2f;

    void Start()
    {
        vignette = ScriptableObject.CreateInstance<Vignette>();
        vignette.enabled.Override(true);
        vignette.intensity.Override(1f);

        volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, vignette);

    }

    public override void ApplyEffect() {
        vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup * speed) * intensity;

    }
}
