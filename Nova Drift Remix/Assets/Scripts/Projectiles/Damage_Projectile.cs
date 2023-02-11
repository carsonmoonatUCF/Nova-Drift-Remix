using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Projectile : MonoBehaviour
{
    // Damage
    [Header("Damage")]
    public float damage = 0.0f;

    // Push force
    [Header("Force")]
    public float pushForce = 0.0f;


    // Set projectile damage.
    public void SetDamage(float dmg){
        this.damage = dmg;
    }

    // Determines what the projectile is hitting.
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Cookie")){
            other.GetComponent<Health_Cookie>().TakeDamage(damage);

            other.GetComponent<Rigidbody2D>().AddForce((other.transform.position - transform.position) * pushForce, ForceMode2D.Impulse);
        }else if(other.transform.CompareTag("Enemy")){
            other.GetComponent<Health_Enemy>().TakeDamage(damage);

            other.GetComponent<Rigidbody2D>().AddForce((other.transform.position - transform.position) * pushForce, ForceMode2D.Impulse);
        }

        Destroy(this.gameObject);
    }
}
