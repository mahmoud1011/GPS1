using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mahmoud Anwar 0130645
public class PlayerMovementBeta : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);

        transform.position = transform.position + (Vector3)(direction * speed * Time.deltaTime);
    }
}
