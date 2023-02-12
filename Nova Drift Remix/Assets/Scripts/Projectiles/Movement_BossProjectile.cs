using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the movement and rotation of boss projectiles.

public class Movement_BossProjectile : MonoBehaviour
{
    // Projectile Speed
    [Header("Projectile Speed")]
    public float speed = 0.0f;

    // Sprite Renderer
    [Header("Sprite Renderer")]
    public Transform graphics = null;
    public float rotationSpeed = 0.0f;


    // Destroy the projectile if it does not hit anything after _ seconds!
    private void Awake() {
        Destroy(this.gameObject, 8f);
    }

    // Moves the projectile on its up axis.
    private void Update() {
        transform.position += transform.up * speed * Time.deltaTime;

        RotateProjectile();
    }

    // Roatate Projectile
    private void RotateProjectile(){
        graphics.Rotate(Vector3.forward, rotationSpeed);
    }
}
