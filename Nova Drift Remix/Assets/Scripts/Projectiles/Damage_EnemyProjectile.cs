using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_EnemyProjectile : MonoBehaviour
{
    // Damage
    [Header("Damage")]
    [SerializeField] private float damage = 0.0f;

    // Push force
    [Header("Force")]
    public float pushForce = 0.0f;


    // Set projectile damage.
    public void SetDamage(float dmg){
        this.damage = dmg;
    }

    // Determines what the projectile is hitting.
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            other.GetComponent<Health_Player>().TakeDamage(damage);

            other.GetComponent<Rigidbody2D>().AddForce((other.transform.position - transform.position) * pushForce, ForceMode2D.Impulse);
        }

        Destroy(this.gameObject);
    }
}
