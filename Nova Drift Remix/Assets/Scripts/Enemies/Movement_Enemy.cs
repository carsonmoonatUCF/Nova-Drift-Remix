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
    public float shotCooldown = 0.0f;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Movement_Player>().transform;
    }

    private void Update() {
        ForwardMovement();
        Rotation();
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

    }
}
