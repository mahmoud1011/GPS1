using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Anwar
public class CameraFollow : MonoBehaviour
{
    public GameObject player; 
    public float smoothTime = 0.3f; // The amount of time for the camera to smoothly follow the player
    public Vector3 offset; // The initial offset between the camera and the player

    private Vector3 velocity = Vector3.zero; // The velocity of the camera

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the target position for the camera to smoothly follow the player
            Vector3 targetPosition = player.transform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
