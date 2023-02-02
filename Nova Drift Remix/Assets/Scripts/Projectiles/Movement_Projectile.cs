using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles projectile forward movement

public class Movement_Projectile : MonoBehaviour
{
    // Projectile Speed
    [Header("Projectile Speed")]
    public float speed = 0.0f;

    private void Update() {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
