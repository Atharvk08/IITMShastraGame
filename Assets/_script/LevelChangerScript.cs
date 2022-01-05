using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChangerScript : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    private void Start()
    {
        animator=GetComponent<Animator>();
    }
    public void OnFadeInComplete()
    {
        gameObject.SetActive(false);
    }
    public void FadeToLevel(int levelIndex)
    {
        gameObject.SetActive(true);
        levelToLoad = levelIndex;
        animator.SetTrigger("Fade");
    }

    public void restartLevel()
    {
        animator.SetTrigger("Fade");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
