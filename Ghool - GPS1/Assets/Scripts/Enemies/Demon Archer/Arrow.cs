using System.Collections;
using UnityEngine;

// Anwar
public class Arrow : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        // Detect when the arrow exits the screen
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detect when the arrow collides with the player
        if (other.CompareTag("Player"))
        {
            // Subtract some health from the player
            //PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            //playerHealth.TakeDamage(10);

            // Destroy the arrow
            Destroy(gameObject);
        }
    }
}
