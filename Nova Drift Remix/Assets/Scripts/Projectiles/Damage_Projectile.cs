using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Projectile : MonoBehaviour
{
    // Damage
    [Header("Damage")]
    private float damage = 0.0f;


    // Set projectile damage.
    public void SetDamage(float dmg){
        this.damage = dmg;
    }

    // Determines what the projectile is hitting.
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Cookie")){
            other.GetComponent<Health_Cookie>().TakeDamage(damage);
        }

        Destroy(this.gameObject);
    }
}
