using System.Collections;
using UnityEngine;

//Mahmoud Anwar 0130645
public class Arrow : MonoBehaviour
{
    public float arrowdmg = 5.0f;
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
            Player player = other.gameObject.GetComponent<Player>();
            if (other.gameObject.tag == ("Player"))
            {
                player.DmgTaken(arrowdmg);
            }
            Destroy(gameObject);
        }
    }
}
