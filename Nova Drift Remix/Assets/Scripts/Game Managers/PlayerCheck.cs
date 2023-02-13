using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    private void Awake() {
        GameObject player = FindObjectOfType<Input_Player>().gameObject;

        if(player){
            Destroy(player);
        }

        GameObject playerUI = FindObjectOfType<HealthBars>().gameObject;

        if(playerUI){
            Destroy(playerUI);
        }
    }
}
