using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles enemy projectiles curved movement

public class Movement_EnemyProjectile : MonoBehaviour
{
    // Projectile Rigidbody2D
    private Rigidbody2D rb = null;

    // Projectile Target
    private Transform target = null;

    // Projectile Movement
    [Header("Movement")]
    public float startSpeed = 0.0f;
    public float travelDuration = 0.0f;
    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        Destroy(this.gameObject, 8f);

        StartCoroutine(ProjectileMovement());
    }

    private void Update() {
        transform.position += transform.up * startSpeed * Time.deltaTime;
    }

    IEnumerator ProjectileMovement(){
        yield return new WaitForSeconds(1f);

        





        /*/
        yield return new WaitForSeconds(1f);

        float travelTime = 0;
        Quaternion startValue = transform.rotation;
        Quaternion endValue = Quaternion.Euler(0, 0, transform.rotation.z + 180);

        while(travelTime < travelDuration){
            transform.rotation = Quaternion.Lerp(startValue, endValue, travelTime / travelDuration);
            travelTime += Time.deltaTime;
            startSpeed += Time.deltaTime * 2;
            yield return null;
        }

        transform.rotation = endValue;
        /*/
    }
}
