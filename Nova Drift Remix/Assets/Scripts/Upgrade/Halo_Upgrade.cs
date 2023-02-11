using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The halo shield does damage to enemies in range, 
// however the player also takes damage!

public class Halo_Upgrade : MonoBehaviour
{
    // Damage Per Damage Rate
    [Header("Damage")]
    public float damageToPlayer = 0.0f;
    public float damageToEnemies = 0.0f;

    // Damage Cooldown
    [Header("Damage Rate")]
    public float damageRate = 0.0f;
    private float damageCooldown = 0.0f;

    // Player Health Script
    private Health_Player playerHealth = null;

    // Player Transform
    private Transform player = null;


    // This object must persist between scenes.
    private void Awake() {
        damageCooldown = damageRate;

        playerHealth = FindObjectOfType<Health_Player>();
        player = playerHealth.gameObject.transform;

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update() {
        damageCooldown -= Time.deltaTime;

        transform.position = player.position;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Cookie") && damageCooldown <= 0){

            other.GetComponent<Health_Cookie>().TakeDamage(damageToEnemies);
            playerHealth.TakeDamage(damageToPlayer);

            damageCooldown = damageRate;
        }

        if(other.CompareTag("Enemy") && damageCooldown <= 0){

            other.GetComponent<Health_Enemy>().TakeDamage(damageToEnemies);
            playerHealth.TakeDamage(damageToPlayer);

            damageCooldown = damageRate;
        }
    }
}
