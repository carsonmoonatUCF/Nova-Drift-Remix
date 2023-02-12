using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles boss health and switches to angry when taken enough damage.

public class Health_Boss : MonoBehaviour
{
    // Boss Health
    [Header("Health")]
    public float maxHealth = 0.0f;
    public float currentHealth = 0.0f;

    // Angry
    [Header("Angry")]
    public bool angry = false;
    public SpriteRenderer spriteRen = null;
    public Sprite angrySprite = null;


    // Set health to max.
    private void Awake() {
        currentHealth = maxHealth;
    }

    private void Update() {
        if(currentHealth <= maxHealth / 2){
            SwitchToAngry();
        }

        if(currentHealth <= 0){
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float amount){
        currentHealth -= amount;
    }

    private void SwitchToAngry(){
        angry = true;

        spriteRen.sprite = angrySprite;
    }

    public bool GetAngry(){
        return angry;
    }
}
