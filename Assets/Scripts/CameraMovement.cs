using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private Transform camera;

    public float SmoothTime = 0.3f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // update position
        Vector3 targetPosition = player.position;
        camera.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

        // update rotation
        transform.LookAt(player);
    }
}
