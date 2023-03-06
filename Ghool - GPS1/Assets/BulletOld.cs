using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOld : MonoBehaviour
{
    Vector3 mousePos;
    private Camera mainCam;
    public float bulletSpeed = 10.0f;
    private Rigidbody2D rb; 
    // Method to set the direction of the bullet
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb= GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
        float rot = Mathf.Atan2(rotation.x, rotation.y)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0,0,rot);

    }

    void Update()
    {
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle collision with other objects
        Destroy(gameObject);
    }
}
