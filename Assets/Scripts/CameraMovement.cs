using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Vector3 offset = new Vector3 (0, 0, -10f);
    [SerializeField] private float smoothTime= 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // update position
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
