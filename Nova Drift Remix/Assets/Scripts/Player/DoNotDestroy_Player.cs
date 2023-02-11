using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player upgrades! Ensures the playe persists through scenes.

public class DoNotDestroy_Player : MonoBehaviour
{
    // Received Upgrade
    private bool receivedUpgrade = false;

    // Blink Upgrade
    [Header("Blink")]
    private Blink_Player blink = null;

    // Halo Upgrade
    [Header("Halo")]
    public GameObject halo = null;

    // Turret Upgrade
    [Header("Turret")]
    private CreateTurret_Player turret = null;

    private void Awake() {
        blink = GetComponent<Blink_Player>();
        turret = GetComponent<CreateTurret_Player>();

        DontDestroyOnLoad(this.gameObject);
    }

    // Enables blink.
    public void EnableBlink(){
        if(!receivedUpgrade){
            blink.enabled = true;
            receivedUpgrade = true;
        }  
    }

    // Enables halo.
    public void EnableHalo(){
        if(!receivedUpgrade){
            Instantiate(halo, transform.position, transform.rotation);
            receivedUpgrade = true;
        }        
    }

    // Enables turret creation.
    public void EnableTurret(){
        if(!receivedUpgrade){
            turret.enabled = true;
            receivedUpgrade = true;
        }  
    }
}
