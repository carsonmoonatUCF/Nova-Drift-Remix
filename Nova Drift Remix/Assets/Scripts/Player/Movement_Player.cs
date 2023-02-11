using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Uses player input and handles player movement.

public class Movement_Player : MonoBehaviour
{
    // Player Input
    Input_Player inputPlayer = null;

    // Player Rigidbody2D
    Rigidbody2D rb = null;

    // Player Rotation
    [Header("Rotation")]
    public float rotationSpeed = 0.0f;
    private Vector3 smoothVelocity = Vector3.zero;

    // Player Thrust
    [Header("Thrust")]
    public float thrustStrength = 0.0f;
    public float maxSpeed = 0.0f;

    // Player Shooting
    [Header("Shooting")]
    public Transform shotPoint = null;
    public GameObject projectile = null;
    public float projectileDamage = 0.0f;
    private bool firstShot = false;
    public float shotCooldown = 0.0f;
    private float cooldown = 0.0f;


    // Get components at runtime.
    private void Awake() {
        inputPlayer = GetComponent<Input_Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Run functions
    private void Update() {
        PlayerRotation();
        PlayerThrust();
        PlayerShooting();
    }


    // Handles Player Rotation, rotates towards the mouse position.
    private void PlayerRotation(){
        Vector3 direction = inputPlayer.GetMousePosition() - transform.position;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref smoothVelocity.y, rotationSpeed);

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    // Handles Player Thrusting, applies force towards mouse position.
    private void PlayerThrust(){
        if(inputPlayer.GetThrust() && rb.velocity.magnitude < maxSpeed){

            rb.AddForce(transform.up * thrustStrength * Time.deltaTime, ForceMode2D.Force);
        }
    }

    // Handles Player Shooting, instantiates projectile at shot point.
    private void PlayerShooting(){
        if(inputPlayer.GetShooting()){
            if(!firstShot){
                CreateProjectile();
                firstShot = true;
                cooldown = shotCooldown;
            }
            
            cooldown -= Time.deltaTime;

            if(cooldown <= 0){
                CreateProjectile();
                cooldown = shotCooldown;
            }  
        }else{
            firstShot = false;
            cooldown = shotCooldown;
        }
    }

    // Handles instantiating the projectile at the shot point.
    private void CreateProjectile(){
        GameObject currentProjectile = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
        currentProjectile.GetComponent<Damage_Projectile>().SetDamage(projectileDamage);
    }
    
}
