using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIScript : MonoBehaviour
{
    

    public void FadeText(Animator anim)
    {
        anim.SetBool("Fade", true);
        new WaitForSeconds(.1f);
        anim.SetBool("Fade", false);
    }
    public void TimeStopped()
    {
        Time.timeScale = 0;
    }
    public void TimeResume()
    {
        Time.timeScale = 1;
    }
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            yield return null;
        }

    }
    public void QuitGame()
    {
        Debug.Log("Game Quit!!!");
        Application.Quit();
    }
}
