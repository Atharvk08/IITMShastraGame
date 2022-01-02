using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyScript : MonoBehaviour
{
    AIPath aipath;
    [SerializeField] private GameObject enemyGFX;

    private bool targetSpotted;
    private bool canEnemyMove;

    public bool getTargetSpotted() { return targetSpotted; }
    public bool getCanEnemyMove() { return canEnemyMove; }
    public void setCanEnemyMove(bool flag) { canEnemyMove = flag; }

    private void Start()
    {
        aipath = GetComponent<AIPath>();
    }
    void FixedUpdate()
    {
        if (aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }else if (aipath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if (aipath.desiredVelocity.y >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }else if(aipath.desiredVelocity.y<=0.01f)
        {
            transform.localScale = new Vector3(1f, -1f, 1f);
        }

    }
    private void Update()
    {
        EnemyStop();
    }
    void EnemyStop()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canEnemyMove)
        {
            aipath.canMove = !aipath.canMove;
        }

    }
}
