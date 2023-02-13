using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the fade in and scale up of the boss.

public class Entrance_Boss : MonoBehaviour
{
    // Spawn Delay
    public float delay = 0.0f;
    public float distance = 0.0f;

    // Sprite Renderer
    public SpriteRenderer spriteRen = null;


    private void Awake() {
        StartCoroutine(ScaleUp());
        StartCoroutine(FadeIn());
    }

    // Scales the boss up.
    IEnumerator ScaleUp(){
        yield return new WaitForSeconds(delay);

        float time = 0.0f;

        float scaleModifier = 0f;
        Vector3 startScale = transform.localScale;

        while(time < distance){
            scaleModifier = Mathf.Lerp(0, 1, time / distance);

            transform.localScale = new Vector3(1, 1, 1) * scaleModifier;

            time += Time.deltaTime;
            
            yield return null;
        }

        transform.localScale = new Vector3(1, 1, 1) * 1;
    }

    // Fades the boss in.
    IEnumerator FadeIn(){
        yield return new WaitForSeconds(delay);

        float time = 0.0f;

        Color startColor = spriteRen.color;
        Color endColor = Color.white;

        while(time < distance){
            spriteRen.color = Color.Lerp(startColor, endColor, time / distance);

            time += Time.deltaTime;

            yield return null;
        }
    }
}
