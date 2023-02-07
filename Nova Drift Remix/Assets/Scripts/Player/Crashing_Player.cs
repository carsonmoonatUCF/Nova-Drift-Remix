using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player crashing, dealing and taking damage.

public class Crashing_Player : MonoBehaviour
{
    // Rigidbody
    private Rigidbody2D rb = null;

    // Player Health
    private Health_Player playerHealth = null;

    // Damage Scale
    [Header("Damage Scaler")]
    public float damageScaler = 0.0f;


    // Get player rigidbody on awake.
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<Health_Player>();
    }

    // Determine what player crashed into, how much damage to take and deal.
    private void OnCollisionEnter2D(Collision2D other) {
        // Deal damage.
        if(other.gameObject.CompareTag("Cookie")){
            other.transform.GetComponent<Health_Cookie>().TakeDamage(rb.velocity.magnitude * damageScaler * 2);
        }

        // Take damage.
        playerHealth.TakeDamage(rb.velocity.magnitude * damageScaler);
    }
}
