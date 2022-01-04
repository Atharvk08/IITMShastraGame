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

    [SerializeField] private GameObject whiteEyes;

   // [SerializeField] private GameObject blood;
    Animator enemyAnimator;
    private void Start()
    {
        aipath = GetComponent<AIPath>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        enemyAnimator = GetComponent<Animator>();
        whiteEyes.SetActive(true);

        //enemyAnimator.SetBool("isAwake", false);
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
            //Instantiate(blood, transform.position, Quaternion.identity);
            //Destroy(gameObject);
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
            enemyAnimator.SetBool("isRunning", true);
            //enemyAnimator.SetBool("isAwake", true);
            whiteEyes.SetActive(false);
        }
        else
        {
            aipath.canMove = false;
            enemyAnimator.SetBool("isRunning", false);
            //enemyAnimator.SetBool("isAwake", false);
            whiteEyes.SetActive(true);
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

    
}
