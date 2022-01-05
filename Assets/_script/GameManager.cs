using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private PlayerScript playerScript;

    [SerializeField] private GameObject LevelChangerObj;
    public WinTileScript winTile;
    private void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
    }

    private void Update()
    {
        if (winTile.playerReachedWinTile)
        {
            //Next Level
            nextLevel();
            return;
        }
        
    }

    public void nextLevel()
    {
        PlayerPrefs.SetString("Level" + SceneManager.GetActiveScene().buildIndex.ToString(), "true");
       // LevelChangerObj.GetComponent<LevelChangerScript>().FadeToLevel(2);
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
}
