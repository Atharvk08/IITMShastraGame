using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    //singleton LevelManager
    /*private static LevelManager Instance;
    private static LevelManager _instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = GameObject.FindGameObjectWithTag("LevelManager").AddComponent<LevelManager>();
            }

            return Instance;
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    public static int currentLevelIndex=3;
    public int maxLevels = 7;
    public Button[] buttons;

    public Sprite currentLevelButtonSprite;
    public Sprite completeLevelButtonSprite;

    private void Start()
    {
        
        for(int i = 3; i < currentLevelIndex; i++)
        {
            buttons[i].image.sprite = completeLevelButtonSprite;
            buttons[currentLevelIndex].interactable = true;
        }
        for (int i = currentLevelIndex; i <=maxLevels; i++)
        {
            buttons[i].interactable = false;
        }
        buttons[currentLevelIndex].image.sprite = currentLevelButtonSprite;
        buttons[currentLevelIndex].interactable = true;

        currentLevelIndex++;
    }

    */
}
