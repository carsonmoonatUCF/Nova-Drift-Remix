using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles boss health and switches to angry when taken enough damage.

public class Health_Boss : MonoBehaviour
{
    // Boss Health
    [Header("Health")]
    public float health = 0.0f;


    private void Update() {
        if(health <= 0){
            // Die!
        }
    }

    public void TakeDamage(float amount){
        health -= amount;
    }
}
