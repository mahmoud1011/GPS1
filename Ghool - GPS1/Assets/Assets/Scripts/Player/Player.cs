using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

//done by: Danial / Alisa
public class Player : MonoBehaviour
{
    public BuffSystem buffSystem; //needed to transfer stat value to BuffSystem Script

    //default
    public float dmaxPlayerHP = 50.0f;
    public float dplayerHP = 50.0f;
    public float dmovementSpeed = 5.0f;
    public float dplayerSize = 1.0f;
    public float dhpLostPerShot = 2.5f;
    public float dhpRegenPerSecond = 0.5f;

    //copy
    public float maxPlayerHP; // Maximum HP represented as a percentage
    public float playerHP; // HP represented as a percentage
    public float movementSpeed;
    public float playerSize;
    public float hpLostPerShot; // HP lost per shot represented as a percentage
    public float hpRegenPerSecond; // HP regenerated per second represented as a percentage

    public Rigidbody2D rb;
    public GameObject bullet;
    private Vector3 mousePosition; // The position of the mouse cursor in world space
    private float timeSinceLastRegen = 0.0f; // Time passed since the last HP regeneration
    public float timeBetweenShot;//Time since last bullet being shoot , can be cosidered as attack speed

    public bool canFire;
    private float timer;

    public Sprite[] playerSprites; // Array of player sprites
    private SpriteRenderer spriteRenderer; // Reference to the player'
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        buffSystem = new BuffSystem();
        buffSystem.GetStats(maxPlayerHP, movementSpeed, timeBetweenShot, hpRegenPerSecond);
        /*buffSystem.GetStats(maxPlayerHP, movementSpeed, timeBetweenShot, hpRegenPerSecond);*/ //fuction to transfer
    }
    private void Update()
    {
        ShootBullet();
        StayOnScreen();
        // Update the player's properties based on its current HP range (may need to simplify into function)
        if (playerHP > 30.0f)
        {
            timeBetweenShot = 1.7f;
            movementSpeed = 8.0f;
            playerSize = 1.0f;
        }
        else if (playerHP > 15.0f)
        {
            timeBetweenShot = 1.3f;
            movementSpeed = 9.0f;
            playerSize = 0.8f;
        }
        else 
        {
            timeBetweenShot = 0.9f;
            movementSpeed = 10.0f;
            playerSize = 0.6f;
        }
        //else
        //{
        //    timeBetweenShot = 0.5f;
        //    movementSpeed = 11.0f;
        //    playerSize = 0.4f;
        //}
        // Update the player's position based on input
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += new Vector3(moveInput.x, moveInput.y, 0) * movementSpeed * Time.deltaTime;

        // Update the player's rotation to point towards the mouse cursor
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        int spriteIndex = Mathf.RoundToInt((angle / 360.0f) * playerSprites.Length) % playerSprites.Length;
        if (spriteIndex < 0)
        {
            spriteIndex += playerSprites.Length;
        }
        spriteRenderer.sprite = playerSprites[spriteIndex];
        //transform.rotation = Quaternion.Euler(0, 0, angle);

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

    public void setStats(float mHp, float atkSpd, float spd, float regen)
    {
        maxPlayerHP = mHp;
        movementSpeed = spd;
        timeBetweenShot = atkSpd;
        hpRegenPerSecond = regen;
    }

    public void ShootBullet()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenShot)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBetweenShot += Time.deltaTime;
            playerHP = Mathf.Clamp(playerHP - hpLostPerShot, 0.0f, maxPlayerHP);
        }

    }

    public void HealingBlob()
    {
        playerHP += 2.5f;
    }

    public void DmgTaken(float dmgAmount)
    {
        Debug.Log($"Damage Amount: {dmgAmount}");
        playerHP -= dmgAmount;
        Debug.Log($"Healht is now: {dmgAmount}");
        if (playerHP <= 0.0f)
        {
            SceneManager.LoadScene(0);
            Debug.Log("Game Over."); // Game over, player is dead
        }
    }


    public void valueReset() //resets values to the default
    {
        maxPlayerHP = dmaxPlayerHP;
        playerHP = dplayerHP;
        movementSpeed = dmovementSpeed;
        playerSize = dplayerHP;
        hpLostPerShot = dhpLostPerShot;
        hpRegenPerSecond = dhpRegenPerSecond;
    }

    public void StayOnScreen()
    {
        if(transform.position.x <= -8.85)
        {
            transform.position = new Vector2(-8.85f, transform.position.y);
        }
        else if(transform.position.x >= 8.85)
        {
            transform.position = new Vector2(8.85f, transform.position.y);
        }
        else if (transform.position.y >= 4.82)
        {
            transform.position = new Vector2(transform.position.x, 4.82f);
        }
        else if (transform.position.y <= -4.82)
        {
            transform.position = new Vector2(transform.position.x, -4.82f);
        }
    }

    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //just incase enemy collision + traps / props
    }

}
