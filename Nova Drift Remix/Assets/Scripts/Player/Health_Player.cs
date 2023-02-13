using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player health, diveded between shield and chassis health.

public class Health_Player : MonoBehaviour
{
    // Shield
    [Header("Shield")]
    public float maxShieldPoints = 0.0f;
    public float shieldPoints = 0.0f;

    // Chassis
    [Header("Chassis")]
    public float maxChassisPoints = 0.0f;
    public float chassisPoints = 0.0f;

    // Regeneration Timer
    [Header("Regen Timer")]
    public float regenRate = 0.0f;
    public float regenTimerLength = 0.0f;
    [SerializeField] private float regenTimer = 0.0f;

    // Sounds
    [Header("Sound Effects")]
    public AudioClip playerTakeDamage = null;
    private AudioSource aSource = null;


    // Set shield and health points to max
    private void Awake() {
        shieldPoints = maxShieldPoints;
        chassisPoints = maxChassisPoints;

        aSource = GetComponent<AudioSource>();
    }

    // Update regen timer
    private void Update() {
        // If the regen timer is below 0.0f, regen shield first then chassis.
        if(regenTimer <= 0.0f){
            if(chassisPoints < maxChassisPoints){
                RegenerateHealth(2);
            }else if(shieldPoints < maxShieldPoints){
                RegenerateHealth(1);
            }
        }

        if(chassisPoints <= 0){
            Destroy(gameObject);
        }

        regenTimer -= Time.deltaTime;
    }

    // On taking damage...
    public void TakeDamage(float amount){
        regenTimer = regenTimerLength;
        aSource.clip = playerTakeDamage;
        aSource.Play();

        if(shieldPoints > 0.0f){
            ApplyDamage(amount, 1);
        }else{
            ApplyDamage(amount, 2);
        }
    }

    // Take Damage
    private void ApplyDamage(float amount, float healthBar){
        if(healthBar == 1){
            shieldPoints -= amount;
        }else{
            chassisPoints -= amount;
        }

        // Protect against negative health bars.
        if(shieldPoints < 0.0f){
            shieldPoints = 0.0f;
        }

        if(chassisPoints < 0.0f){
            chassisPoints = 0.0f;
        }  
    }

    // Regenerate
    private void RegenerateHealth(float healthBar){
        if(healthBar == 1){
            shieldPoints += Time.deltaTime * regenRate;
        }else{
            chassisPoints += Time.deltaTime * regenRate;
        }


        // Protect in case regen goes beyond max health.
        if(shieldPoints > maxShieldPoints){
            shieldPoints = maxShieldPoints;
        }

        if(chassisPoints > maxChassisPoints){
            chassisPoints = maxChassisPoints;
        }      
    }
}
