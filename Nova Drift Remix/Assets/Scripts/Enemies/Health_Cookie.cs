using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles cookie asteroid health and splitting.

public class Health_Cookie : MonoBehaviour
{
    // Health
    [Header("Health")]
    public float cookieHealth = 0.0f;


    // Splits the cookie into smaller cookies if health is below 0.
    private void Update() {
        if(cookieHealth <= 0.0f){
            // Instantiate smaller cookies!
            Destroy(this.gameObject);
        }
    }

    // Applies damage to the cookie asteroid.
    public void TakeDamage(float amount){
        cookieHealth -= amount;
    }
}
