using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mahmoud Anwar 0130645
public class DemonSoilder : MonoBehaviour
{
    public static event Action<DemonSoilder> OnEnemyKilled;

    // Stats
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float moveSpeed = 2f;
    public float damage = 10.0f;
    private float knockbackForce = 4.0f;


    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * MathF.PI;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Damage Amount: {damageAmount}");
        health -= damageAmount;
        Debug.Log($"Healht is now: {health}");

        if (health <= 0)
        {
            EnemySpawner enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
            enemySpawner.DecreaseEn();
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(collision.gameObject.tag==("Player"))
        {
            player.DmgTaken(damage);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Vector2 direction = transform.position - collision.transform.position;
            direction.Normalize();
            GetComponent<Rigidbody2D>().AddForce(direction * knockbackForce, ForceMode2D.Impulse);
            StartCoroutine(StopKnockback());
        }
    }

    private IEnumerator StopKnockback()
    {
        yield return new WaitForSeconds(0.3f); // wait for half a second
        GetComponent<Rigidbody2D>().velocity = Vector3.zero; // or Rigidbody2D.velocity = Vector2.zero; for 2D
    }
}
