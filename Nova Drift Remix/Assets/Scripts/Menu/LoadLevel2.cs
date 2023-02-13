using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel2 : MonoBehaviour
{
    public Animator animator;
    
    private int levelToLoad;
    
    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(4);
        FadeToLevel(4);
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(0);
        FadeToLevel(0);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
        FadeToLevel(1);
    }

        public void LoadCoderLevel()
    {
        SceneManager.LoadScene(5);
        FadeToLevel(5);
    }

        public void QuitGame()
    {
        Application.Quit();
    }


}
