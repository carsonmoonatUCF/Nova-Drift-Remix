using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Turret shoots at the closest enemy or asteroid!
// Constantly takes self damage until destroyed.

public class Turret_Upgrade : MonoBehaviour
{
    // Turret Health
    [Header("Turret Health")]
    public float health = 0.0f;

    // Enemies in Range
    [Header("Enemies in Range")]
    public List<Transform> enemies = new List<Transform>();
    public Transform closest = null;

    // Turret Rotation
    [Header("Rotation Speed")]
    public float rotationSpeed = 0.0f;
    private Vector3 smoothVelocity = Vector3.zero;

    // Turret Shooting
    [Header("Turret Shooting")]
    public Transform shotPoint1 = null;
    public Transform shotPoint2 = null;
    public GameObject projectile = null;
    public float shotRate = 0.0f;
    private float shotCooldown = 0.0f;
    private int shotPointInt = 0;


    private void Awake() {
        shotCooldown = shotRate;
    }

    private void Update() {
        if(enemies.Count > 0){
            closest = ClosestEnemy();
            TurretRotation();
            TurretShoot();
        }else{
            closest = null;
        }

        shotCooldown -= Time.deltaTime;

        health -= Time.deltaTime;

        if(health <= 0){
            Destroy(this.gameObject);
        }
    }

    // Add enemies to list if in range.
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Cookie") || other.CompareTag("Enemy")){
            enemies.Add(other.transform);
        }
    }

    // Remove enemies from list if out of range.
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Cookie") || other.CompareTag("Enemy")){

            for(int i=0; i<enemies.Count; i++){

                if(other.transform == enemies[i]){
                    enemies.Remove(enemies[i]);
                }
            }
        }
    }

    // Find closest enemy in range.
    private Transform ClosestEnemy(){

        Transform closestEnemy = null;
        float closestDistance = 0;

        for(int i=0; i<enemies.Count; i++){
            float distance = Vector2.Distance(transform.position, enemies[i].position);

            if(distance < closestDistance || closestDistance == 0){
                closestDistance = distance;
                closestEnemy = enemies[i];
            }else{
                break;
            }
        }

        return closestEnemy;
    }

    // Rotate Turret towards closest enemy.
    private void TurretRotation(){
        Vector3 direction = closest.position - transform.position;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref smoothVelocity.y, rotationSpeed);

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    // Shoot when there are enemies in range.
    private void TurretShoot(){
        if(shotCooldown <= 0){

            if(shotPointInt == 0){
                Instantiate(projectile, shotPoint1.position, shotPoint1.rotation);
                shotPointInt = 1;
            }else{
                Instantiate(projectile, shotPoint2.position, shotPoint2.rotation);
                shotPointInt = 0;
            }
            
            shotCooldown = shotRate;
        }
    }
}
