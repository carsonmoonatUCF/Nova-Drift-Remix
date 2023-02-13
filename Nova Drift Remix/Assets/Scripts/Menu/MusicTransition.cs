using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicTransition : MonoBehaviour
{
    private static MusicTransition instance;

    void Awake ()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        if (SceneManager.GetActiveScene().name == "WinScreen")
            MusicTransition.instance.GetComponent<AudioSource>().Pause();

        if (SceneManager.GetActiveScene().name == "LoseScreen")
            MusicTransition.instance.GetComponent<AudioSource>().Pause();
    }
}
