using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the movement and rotation of boss projectiles.

public class Movement_BossProjectile : MonoBehaviour
{
    // Projectile Speed
    [Header("Projectile Speed")]
    public float speed = 0.0f;


    // Destroy the projectile if it does not hit anything after _ seconds!
    private void Awake() {
        Destroy(this.gameObject, 10f);
    }

    // Moves the projectile on its up axis.
    private void Update() {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
