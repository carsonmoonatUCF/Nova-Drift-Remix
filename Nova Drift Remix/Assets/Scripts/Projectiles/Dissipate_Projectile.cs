using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles projectile slowly fading out

public class Dissipate_Projectile : MonoBehaviour
{
    // Projectile Distance
    public float distance = 0.0f;

    // Delay
    public float delay = 0.0f;

    // Sprite Renderer
    public SpriteRenderer spriteRen = null;



    // Starts both coroutines.
    private void Awake() {
        StartCoroutine(ScaleDown());
        StartCoroutine(FadeOut());
    }

    // Scales the projectile down and destroys it at the end.
    IEnumerator ScaleDown(){
        yield return new WaitForSeconds(delay);

        float time = 0.0f;

        float scaleModifier = 1f;
        Vector3 startScale = transform.localScale;

        while(time < distance){
            scaleModifier = Mathf.Lerp(1, 0, time / distance);

            transform.localScale = startScale * scaleModifier;

            time += Time.deltaTime;
            
            yield return null;
        }

        Destroy(this.gameObject);
    }

    // Lowers the opacity.
    IEnumerator FadeOut(){
        yield return new WaitForSeconds(delay);

        float time = 0.0f;

        Color startColor = spriteRen.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);

        while(time < distance){
            spriteRen.color = Color.Lerp(startColor, endColor, time / distance);

            time += Time.deltaTime;

            yield return null;
        }
    }
}
