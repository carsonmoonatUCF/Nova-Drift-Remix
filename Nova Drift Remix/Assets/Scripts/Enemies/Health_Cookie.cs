using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles cookie asteroid health and splitting.

public class Health_Cookie : MonoBehaviour
{
    // Health
    [Header("Health")]
    public float cookieHealth = 0.0f;

    // Cookie Collider
    [Header("Collider")]
    public CircleCollider2D cookieCol = null;

    // Cookie Crumbs
    [Header("Crumbs")]
    public bool hasCrumbs = false;
    public GameObject[] crumbs = null;
    public float crumbSpeed = 0.0f;
    public float crumbTorque = 0.0f;

    // Cookie Explosion
    public GameObject cookieExplosion = null;


    private void Awake() {
        cookieCol = GetComponent<CircleCollider2D>();
    }

    // Splits the cookie into smaller cookies if health is below 0.
    private void Update() {
        if(cookieHealth <= 0.0f){
            if(hasCrumbs)
                Crumbs();
            else
                Destroy(this.gameObject);
        }
    }

    // Applies damage to the cookie asteroid.
    public void TakeDamage(float amount){
        cookieHealth -= amount;
    }

    // Release the crumbs!
    private void Crumbs(){
        cookieCol.enabled = false;

        for(int i=0; i<crumbs.Length; i++){
            crumbs[i].SetActive(true);

            Rigidbody2D cRB = crumbs[i].GetComponent<Rigidbody2D>();

            Vector3 direction = crumbs[i].transform.position - transform.position;

            cRB.AddForce(direction * crumbSpeed, ForceMode2D.Impulse);

            cRB.AddTorque(Random.Range(-crumbTorque, crumbTorque));

            crumbs[i].transform.parent = null;
        }

        GameObject explosion = Instantiate(cookieExplosion, transform.position, transform.rotation);
        Destroy(explosion, 4f);
        Destroy(this.gameObject);
    }
}
