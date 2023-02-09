using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles enemy projectiles curved movement

public class Movement_EnemyProjectile : MonoBehaviour
{
    // Projectile Rigidbody2D
    private Rigidbody2D rb = null;

    // Projectile Target
    public Vector3 shotTarget = Vector3.zero;

    // Projectile Movement
    [Header("Movement")]
    public float startSpeed = 0.0f;
    public float travelDuration = 0.0f;
    public float rotationSpeed = 0.0f;
    private Vector3 smoothVelocity = Vector3.zero;
    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        Destroy(this.gameObject, 8f);

        StartCoroutine(ProjectileMovement());
    }

    private void Update() {
        transform.position += transform.up * startSpeed * Time.deltaTime;
        startSpeed += Time.deltaTime;
    }

    public void GetShotTarget(Vector3 target){
        shotTarget = target;
    }

    IEnumerator ProjectileMovement(){
        yield return new WaitForSeconds(1f);    

        float travelTime = 0;

        while(travelTime < travelDuration){

            Vector3 direction = shotTarget - transform.position;

            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref smoothVelocity.y, rotationSpeed);

            transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
            
            travelTime += Time.deltaTime;
            //startSpeed += Time.deltaTime;
            yield return null;
        }
    }
}
