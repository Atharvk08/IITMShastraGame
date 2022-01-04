using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyScript : MonoBehaviour
{
    AIPath aipath;
    [SerializeField]private PlayerScript playerScript;
    private bool playerDetected;
    [SerializeField] private bool canMove;
    private void Start()
    {
        aipath = GetComponent<AIPath>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

        aipath.canMove = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerTorchLight"))
        {
            playerDetected = true;
            Debug.Log("target spotted");
        }
        if (collision.CompareTag("Spikes"))
        {
            Destroy(gameObject);
            Debug.Log("enemy detsoref");
        }
    }
    void FixedUpdate()
    {
        Flip();
        canMove = playerScript.getTorchEnabled() && playerDetected;
        if (canMove)
        {
            aipath.canMove = true;
            Debug.Log(canMove);
        }
        else
        {
            aipath.canMove = false;
        }
    }

    void Flip()
    {
        if (aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aipath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aipath.desiredVelocity.y >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aipath.desiredVelocity.y <= 0.01f)
        {
            transform.localScale = new Vector3(1f, -1f, 1f);
        }
    }

    private void Update()
    {

    }
    
}
