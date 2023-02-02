using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player health, diveded between shield and chassis health.

public class Health_Player : MonoBehaviour
{
    // Shield
    [Header("Shield")]
    public float shieldPoints = 0.0f;

    // Chassis
    [Header("Chassis")]
    public float chassisPoints = 0.0f;


    // On taking damage...
    public void TakeDamage(float amount){
        if(shieldPoints > 0.0f){
            ShieldDamage(amount);
        }else{
            ChassisDamage(amount);
        }
    }

    // Take Damage on Shield
    private void ShieldDamage(float amount){
        shieldPoints -= amount;

        if(shieldPoints < 0.0f){
            shieldPoints = 0.0f;
        }       
    }

    // Take Damage on Chasis
    private void ChassisDamage(float amount){
        chassisPoints -= amount;

        if(chassisPoints <= 0.0f){
            // Lose!
        }
    }
}
