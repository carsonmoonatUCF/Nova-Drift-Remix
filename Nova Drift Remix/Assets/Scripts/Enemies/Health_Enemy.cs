using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles enemy health and taking damage.

public class Health_Enemy : MonoBehaviour
{
    // Enemy Health
    public float health = 0.0f;

    // Enemy Explosion
    public GameObject enemyExplosion = null;


    private void Update() {
        if(health <= 0){
            GameObject explosion = Instantiate(enemyExplosion, transform.position, transform.rotation);
            Destroy(explosion, 5f);
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float amount){
        health -= amount;
    }
}
