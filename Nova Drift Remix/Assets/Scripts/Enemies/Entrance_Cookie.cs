using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the force applied to enter the screen.

public class Entrance_Cookie : MonoBehaviour
{
    // Rigidbody
    private Rigidbody2D rb = null;

    // Entrance Force
    public float entranceForce = 0.0f;

    // Scale
    public float minScale = 0.0f;
    public float maxScale = 0.0f;


    // Picks a random scale and pushes the cookie into frame.
    private void Awake() {
        // Start with random scale.
        float thisScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(thisScale, thisScale, thisScale);

        // Start with random rotation.
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Random.Range(0, 360));

        // Start with random force and torque.
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Random.Range(4, 8) * (Vector3.up + Vector3.right), ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(0, 10));
    }
}
