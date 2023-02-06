using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles projectile forward movement

public class Movement_Projectile : MonoBehaviour
{
    // Projectile Speed
    [Header("Projectile Speed")]
    public float speed = 0.0f;


    // Destroy the projectile if it does not hit anything after 3 seconds!
    private void Awake() {
        Destroy(this.gameObject, 2f);
    }

    // Moves the projectile on its up axis.
    private void Update() {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
