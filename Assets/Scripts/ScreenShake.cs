using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private bool hasEffect;
    [SerializeField] private float duration = 3f;
    [SerializeField] private float tempDuration;
    // Start is called before the first frame update
    void Start()
    {
        tempDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasEffect)
        {
            if (tempDuration > 0)
            {
                tempDuration -= Time.deltaTime;
                camera.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(-22.5f, 22.5f));
            }
            if (tempDuration <= 0)
            {
                hasEffect = false;
                tempDuration = duration;
            }
        }
    }
}
