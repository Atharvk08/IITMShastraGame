using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private PlayerScript playerScript;

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
        }
    }
    
}
