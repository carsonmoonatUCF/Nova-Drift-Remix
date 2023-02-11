using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player input during gameplay.

public class Input_Player : MonoBehaviour
{
    // Player Input Actions
    PlayerControls controls = null;

    // Main Camera
    Camera cam = null;

    // Input Values
    [Header("Player Input Containers")]
    [SerializeField] private Vector3 worldMousePosition = Vector2.zero;
    [SerializeField] private bool shooting = false;
    [SerializeField] private bool thrusters = false;
    [SerializeField] private bool blinking = false;
    [SerializeField] private bool turret = false;


    // Get input actions and assign inputs
    private void Awake() {
        controls = new PlayerControls();

        controls.Gameplay.MousePosition.performed += ctx => ReceiveMousePosition(ctx.ReadValue<Vector2>());

        controls.Gameplay.Shoot.started += ctx => OnShoot();
        controls.Gameplay.Shoot.canceled += ctx => StopShoot();

        controls.Gameplay.Thrust.started += ctx => OnThrust();
        controls.Gameplay.Thrust.canceled += ctx => StopThrust();

        controls.Gameplay.Blink.started += ctx => OnBlink();
        controls.Gameplay.Blink.canceled += ctx => StopBlink();

        controls.Gameplay.Turret.started += ctx => OnTurret();
        controls.Gameplay.Turret.canceled += ctx => StopTurret();
    }


    // Receive input from player.
    private void ReceiveMousePosition(Vector2 ctx){
        Vector3 fixedMousePos = new Vector3(ctx.x, ctx.y, 1f);
        cam = Camera.main;
        worldMousePosition = cam.ScreenToWorldPoint(fixedMousePos);
    }

    private void OnShoot(){
        shooting = true;
    }

    private void StopShoot(){
        shooting = false;
    }

    private void OnThrust(){
        thrusters = true;
    }

    private void StopThrust(){
        thrusters = false;
    }

    private void OnBlink(){
        blinking = true;
    }

    private void StopBlink(){
        blinking = false;
    }

    private void OnTurret(){
        turret = true;
    }

    private void StopTurret(){
        turret = false;
    }


    // Get Input
    public Vector3 GetMousePosition(){
        return worldMousePosition;
    }

    public bool GetThrust(){
        return thrusters;
    }

    public bool GetShooting(){
        return shooting;
    }

    public bool GetBlinking(){
        return blinking;
    }

    public bool GetTurret(){
        return turret;
    }


    // Enable and Disable input
    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }
}
