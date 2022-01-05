using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public static int currentLevelIndex=1;
    int maxLevel = 5;

    public List<Button> buttons;

    public Sprite currentLevelButtonSprite;
    public Sprite completeLevelButtonSprite;
    public void LoadLevel(int levelIndex)
    {
        if (currentLevelIndex <= 5)
        {

        }
    }
}
