using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Anwar
public class DemonArcherHP : MonoBehaviour
{
    public static event Action<DemonArcherHP> OnEnemyKilled;

    [SerializeField] float health, maxHealth = 3f;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Damage Amount: {damageAmount}");
        health -= damageAmount;
        Debug.Log($"Healht is now: {health}");

        if (health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }
}
