using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles Player creation of turret object.

public class CreateTurret_Player : MonoBehaviour
{
    // Player Input
    private Input_Player input = null;

    // Turret
    [Header("Turret")]
    public GameObject turret = null;
    public GameObject currentTurret = null;


    private void Awake() {
        input = GetComponent<Input_Player>();
    }

    private void Update() {
        if(input.GetTurret()){
            CreateTurret();
        }
    }

    // Creates a turret at the players location.
    private void CreateTurret(){
        if(!currentTurret){
            currentTurret = Instantiate(turret, transform.position, transform.rotation);
        }
    }


}
