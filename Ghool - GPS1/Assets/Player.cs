using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float maxPlayerHP = 100.0f; // Maximum HP represented as a percentage
    public float playerHP = 100.0f; // HP represented as a percentage
    public float fireRate = 1.0f;
    public float movementSpeed = 5.0f;
    public float playerSize = 1.0f;
    public float hpLostPerShot = 5.0f; // HP lost per shot represented as a percentage
    public float hpRegenPerSecond = 1.0f; // HP regenerated per second represented as a percentage

    public Rigidbody2D rb;
    public GameObject bullet;
    private Vector3 mousePosition; // The position of the mouse cursor in world space
    private float timeSinceLastRegen = 0.0f; // Time passed since the last HP regeneration
    public float timeSinceLastShot;//Time since last bullet being shoot , can be cosidered as attack speed

    public bool canFire;
    private float timer;
    

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }
     private void Update()
    {
        ShootBullet();
        // Update the player's properties based on its current HP range
        if (playerHP > 50.0f)
        {
            timeSinceLastShot = 1.5f;
            movementSpeed = 5.0f;
            playerSize = 1.0f;
        }
        else if (playerHP > 30.0f)
        {
            timeSinceLastShot = 1.0f;
            movementSpeed = 7.0f;
            playerSize = 0.8f;
        }
        else if (playerHP > 15.0f)
        {
            timeSinceLastShot = 0.8f;
            movementSpeed = 9.0f;
            playerSize = 0.6f;
        }
        else
        {
            timeSinceLastShot = 0.5f;
            movementSpeed = 11.0f;
            playerSize = 0.4f;
        }
        // Update the player's position based on input
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += new Vector3(moveInput.x, moveInput.y, 0) * movementSpeed * Time.deltaTime;

        // Update the player's rotation to point towards the mouse cursor
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0,angle);

        // Update the player's properties
        transform.localScale = new Vector3(playerSize, playerSize, playerSize);
        // ...

        // Regenerate HP every second
        timeSinceLastRegen += Time.deltaTime;
        if (timeSinceLastRegen >= 1.0f)
        {
            playerHP = Mathf.Clamp(playerHP + maxPlayerHP * (hpRegenPerSecond / 100.0f), 0.0f, maxPlayerHP);
            timeSinceLastRegen = 0.0f;
        }
        
    }

    public void ShootBullet()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeSinceLastShot)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetKey(KeyCode.Space)&& canFire)
        {
            canFire=false;
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeSinceLastShot += Time.deltaTime;
            playerHP = Mathf.Clamp(playerHP - hpLostPerShot, 0.0f, maxPlayerHP);
            

        }

    }
    public void HealingBlob()
    {
        playerHP += 5f;
    }

    public void DmgTaken(float dmgAmount)
    {
        Debug.Log($"Damage Amount: {dmgAmount}");
        playerHP -= dmgAmount;
        Debug.Log($"Healht is now: {dmgAmount}");
        if (playerHP <= 0.0f)
        {
            // Game over, player is dead
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
