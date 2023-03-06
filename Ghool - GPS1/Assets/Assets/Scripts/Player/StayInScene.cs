using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInScene : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 8.85f, -8.85f), Mathf.Clamp(transform.position.y, 4.82f, -4.82f), transform.position.z);
    }

}
