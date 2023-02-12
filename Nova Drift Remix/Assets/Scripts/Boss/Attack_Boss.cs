using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the boss regular attack and angered attack.

public class Attack_Boss : MonoBehaviour
{
    // Boss Health Script
    private Health_Boss bossHealth = null;

    // Boss Regular Attack
    [Header("Regular Attack Pattern")]
    public Transform attackPosition = null;
    public Transform[] shotPoints = null;
    private int shotPointInt = 0;
    public float rotateSpeed = 0.0f;

    [Header("Attack Cooldown")]
    public float attackCooldown = 0.0f;
    public float startAttackCooldown = 0.0f;
    public float attackRate = 0.0f;
    public float attackRateCooldown = 0.0f;


    [Header("Projectile")]
    public GameObject projectile = null;


    private void Awake() {
        attackCooldown = -5;

        bossHealth = GetComponent<Health_Boss>();
    }

    private void Update() {
        attackPosition.transform.RotateAround(transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);

        if(attackCooldown > 0){
            print("Attack!");
            RegularAttack();
        }

        if(attackCooldown <= -8 || bossHealth.GetAngry()){
            attackCooldown = startAttackCooldown;
        }

        if(!bossHealth.GetAngry())
            attackCooldown -= Time.deltaTime;
    }

    private void RegularAttack(){
        attackRateCooldown -= Time.deltaTime;

        if(attackRateCooldown <= 0){
            shotPointInt++;

            if(shotPointInt == shotPoints.Length){
                shotPointInt = 0;
            }

            Instantiate(projectile, shotPoints[shotPointInt].position, shotPoints[shotPointInt].rotation);

            attackRateCooldown = attackRate;
        }
    }
}
