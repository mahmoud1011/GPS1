using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerStats playerStats; //needed to transfer speed value to PlayerStats Script

    public float movementspeed= 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    PlayerStats playerhp;
    private void Start()
    {
        playerStats.GetSpeed(movementspeed); //fuction to transfer
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(movement.x, movement.y);

        transform.position = transform.position + (Vector3)(direction * movementspeed * Time.deltaTime);

        movementspeedthreshold();

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement *movementspeed * Time.fixedDeltaTime);
    }

    public void movementspeedthreshold()
    {
        if (GetComponent<PlayerStats>().currentHealth >= 80 && GetComponent<PlayerStats>().currentHealth <= 100)
        {
            movementspeed = 5f;
        }
        else if (GetComponent<PlayerStats>().currentHealth >= 60 && GetComponent<PlayerStats>().currentHealth <= 79)
        {
            movementspeed = 10f;
        }
        else if (GetComponent<PlayerStats>().currentHealth >= 40 && GetComponent<PlayerStats>().currentHealth <= 59)
        {
            movementspeed = 15f;
        }
        else if (GetComponent<PlayerStats>().currentHealth >= 20 && GetComponent<PlayerStats>().currentHealth <= 39)
        {
            movementspeed = 20f;
        }
        else
        {
            movementspeed = 25f;
        }
    }
}
