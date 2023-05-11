using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Mathf.Lerp(gameObject.transform.position.x, player.position.x, speed), Mathf.Lerp(gameObject.transform.position.y, player.position.y, speed), -10);
    }
}
