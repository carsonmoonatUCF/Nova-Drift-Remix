using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles boss health and switches to angry when taken enough damage.

public class Health_Boss : MonoBehaviour
{
    // Boss Health
    [Header("Health")]
    public float maxHealth = 0.0f;
    public float currentHealth = 0.0f;

    // Angry
    [Header("Angry")]
    public bool angry = false;
    public SpriteRenderer spriteRen = null;
    public Sprite angrySprite = null;

    // Sound Effects
    [Header("Sound Effects")]
    private AudioSource aSource = null;

    // Boss Explosion
    [Header("Boss Explosion")]
    public GameObject bossExplosion;


    // Set health to max.
    private void Awake() {
        currentHealth = maxHealth;

        aSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if(currentHealth <= maxHealth / 2){
            SwitchToAngry();
        }

    //load win screen 
        if(currentHealth <= 0){
            GameObject explosion = Instantiate(bossExplosion, transform.position, transform.rotation);
            Destroy(explosion, 4f);

            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
        }
    }

    public void TakeDamage(float amount){
        currentHealth -= amount;

        aSource.Play();
    }

    private void SwitchToAngry(){
        angry = true;

        spriteRen.sprite = angrySprite;
    }

    public bool GetAngry(){
        return angry;
    }
}
