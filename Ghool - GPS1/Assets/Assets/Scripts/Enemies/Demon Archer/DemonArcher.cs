using System.Collections;
using UnityEngine;

//Mahmoud Anwar 0130645
public class DemonArcher : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float shootDelay = 2f;
    public float shootingRange = 10f;
    public float attackSpeed = 10f;

    private Transform playerTransform;
    private float shootTimer = 0f;

    // To customize the random area the enemy moves in
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float speed = 5.0f;

    private Vector3 targetPosition;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        SetTargetPosition();
    }

    private void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootDelay)
        {
            ShootArrow();
            shootTimer = 0f;
        }

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // If the enemy has reached the target position, set a new target position
        if (transform.position == targetPosition)
        {
            SetTargetPosition();
        }

        // Flip the enemy sprite to face the player
        Vector3 direction = playerTransform.position - transform.position;
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    private void ShootArrow()
    {
        Vector3 shootDirection = playerTransform.position - transform.position;

        if (shootDirection.magnitude > shootingRange)
        {
            return;
        }

        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().velocity = shootDirection.normalized * attackSpeed;
    }

    private void SetTargetPosition()
    {
        // Generate a new random target position within the defined boundary
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector3(randomX, randomY, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Do not damage the player if touched
    }
}
