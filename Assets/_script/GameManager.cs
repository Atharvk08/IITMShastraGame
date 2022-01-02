using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private PlayerScript playerScript;

    private void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
