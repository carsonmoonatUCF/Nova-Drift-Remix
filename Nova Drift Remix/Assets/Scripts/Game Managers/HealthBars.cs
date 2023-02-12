using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Handles the display of shield and chassis health.

public class HealthBars : MonoBehaviour
{
    // Player Health Script
    private Health_Player playerHealth = null;

    // Shield Bar
    [SerializeField] private Image shieldBar = null;

    // Chassis Bar
    [SerializeField] private Image chassisBar = null;


    // Get player script on awake.
    private void Awake() {
        playerHealth = FindObjectOfType<Health_Player>();
    }

    // Update shield and chassis display.
    private void Update() {
        shieldBar.fillAmount = (playerHealth.shieldPoints / playerHealth.maxShieldPoints);

        chassisBar.fillAmount = (playerHealth.chassisPoints / playerHealth.maxChassisPoints);
    }
}
