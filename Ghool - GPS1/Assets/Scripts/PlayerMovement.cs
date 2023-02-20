using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementspeed= 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    PlayerHP playerhp;
    private void Start()
    {
       
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movementspeedthreshold();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement *movementspeed * Time.fixedDeltaTime);
    }

    public void movementspeedthreshold()
    {
        if (GetComponent<PlayerHP>().currentHealth >= 80 && GetComponent<PlayerHP>().currentHealth <= 100)
        {
            movementspeed = 5f;
        }
        else if (GetComponent<PlayerHP>().currentHealth >= 60 && GetComponent<PlayerHP>().currentHealth <= 79)
        {
            movementspeed = 10f;
        }
        else if (GetComponent<PlayerHP>().currentHealth >= 40 && GetComponent<PlayerHP>().currentHealth <= 59)
        {
            movementspeed = 15f;
        }
        else if (GetComponent<PlayerHP>().currentHealth >= 20 && GetComponent<PlayerHP>().currentHealth <= 39)
        {
            movementspeed = 20f;
        }
        else
        {
            movementspeed = 25f;
        }
    }
}
