using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles enemy forward movement, turning, and shooting

public class Movement_Enemy : MonoBehaviour
{
    // Rigidbody2D
    private Rigidbody2D rb = null;

    // Target (Player)
    [SerializeField] private Transform target = null;

    // Movement
    [Header("Movement")]
    public float maxSpeed = 0.0f;
    public float forwardThrust = 0.0f;

    // Rotation
    [Header("Rotation")]
    public float rotationSpeed = 0.0f;
    private Vector3 smoothVelocity = Vector3.zero;

    // Shooting
    [Header("Shooting")]
    public Transform[] shotPositions = null;
    public Transform shotTarget = null;
    public GameObject enemyProjectile = null;
    public float shotCooldownLength = 0.0f;
    private float shotCooldown = 0.0f;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Movement_Player>().transform;
        shotCooldown = shotCooldownLength;
    }

    private void Update() {
        ForwardMovement();
        Rotation();
        Fire();

        shotCooldown -= Time.deltaTime;
    }

    // Handles Enemy forward thrust
    private void ForwardMovement(){
        if(rb.velocity.magnitude < maxSpeed)
            rb.AddForce(transform.up * forwardThrust * Time.deltaTime, ForceMode2D.Force);
    }

    // Handles Enemy rotation towards player
    private void Rotation(){
        Vector3 direction = target.position - transform.position;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref smoothVelocity.y, rotationSpeed);

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    // Handles Enemy shooting
    private void Fire(){

        if(shotCooldown <= 0.0f){

            for(int i=0; i<shotPositions.Length; i++){
                GameObject currentProjectile = Instantiate(enemyProjectile, shotPositions[i].transform.position, shotPositions[i].transform.rotation);
                currentProjectile.GetComponent<Damage_EnemyProjectile>().SetDamage(25);
                currentProjectile.GetComponent<Movement_EnemyProjectile>().GetShotTarget(shotTarget.position);
            }

            shotCooldown = shotCooldownLength;
        }
        
    }
}
