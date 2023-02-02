using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defines boundaries and teleports the object if they go outside of them.

public class ScreenWrapping : MonoBehaviour
{
    // Boundaries
    [Header("Boundaries")]
    public float xBound = 0.0f;
    public float yBound = 0.0f;


    // Continuously check if object violates any of the bounds.
    private void Update() {
        if(transform.position.x > xBound){
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);

        }else if(transform.position.x < -xBound){
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);

        }else if(transform.position.y > yBound){
            transform.position = new Vector3(transform.position.x, -yBound, transform.position.z);

        }else if(transform.position.y < -yBound){
            transform.position = new Vector3(transform.position.x, yBound, transform.position.z);

        }
    }

}
