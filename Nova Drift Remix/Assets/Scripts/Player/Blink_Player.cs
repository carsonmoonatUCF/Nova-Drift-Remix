using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Blinking allows the player to teleport forward.

public class Blink_Player : MonoBehaviour
{
    // Player Input
    private Input_Player playerInput = null;

    // Blink Distance
    [Header("Blink Distance")]
    public float blinkDistance = 0.0f;

    // Blink Cooldown
    [Header("Blink Rate")]
    public float blinkRate = 0.0f;
    private float blinkCooldown = 0.0f;


    private void Awake() {
        playerInput = GetComponent<Input_Player>();
    }

    private void Update() {
        if(blinkCooldown <= 0 && playerInput.GetBlinking()){
            Blink();
            blinkCooldown = blinkRate;
        }

        blinkCooldown -= Time.deltaTime;
    }

    private void Blink(){
        print("Blink!");
        transform.position += transform.up * blinkDistance;
    }




}
