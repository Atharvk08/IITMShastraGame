using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTileScript : MonoBehaviour
{
    public bool playerReachedWinTile;
    public GameObject youWinPanel;

    private void Start()
    {
        playerReachedWinTile = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Wins");
            playerReachedWinTile = true;
            youWinPanel.SetActive(true);
        }
    }
}
