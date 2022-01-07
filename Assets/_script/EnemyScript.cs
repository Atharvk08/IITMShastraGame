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

    [SerializeField] private GameObject spiderBlood;
    [SerializeField] private GameObject blood;

    [SerializeField] private GameObject spiderEyesLights;

    [SerializeField] private GameObject restartMenu;
    Animator enemyAnimator;

    public GameObject eyes1;
    public GameObject eyes2;

    [SerializeField] private float spiderStartTime=5f;
    private void Start()
    {
        aipath = GetComponent<AIPath>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        enemyAnimator = GetComponent<Animator>();
        whiteEyes.SetActive(true);

       // spiderEyesLights.SetActive(false);
        aipath.canMove = false;
        eyes1.SetActive(false);
        eyes2.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerTorchLight"))
        {
            playerDetected = true;
            Debug.Log("target spotted");
            // spiderEyesLights.SetActive(true);
            eyes1.SetActive(true);
            eyes2.SetActive(true);
        }
        if (collision.CompareTag("Spikes"))
        {
            //Instantiate(blood, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            Debug.Log("enemy detsoref");
            Instantiate(spiderBlood, transform.position, Quaternion.identity);
            canMove = false;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.Find("playerGFX").gameObject.SetActive(false);
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            canMove = false;
            RestartMenu(collision.gameObject);
        }
    }

    public void RestartMenu()
    {
        //Time.timeScale = 0;
        new WaitForSecondsRealtime(.45f);
        restartMenu.SetActive(true);
    }

    void FixedUpdate()
    {
        Flip();
        canMove = playerScript.getTorchEnabled() && playerDetected;
        if (canMove)
        {
            enemyAnimator.SetBool("isRunning", true);
            new WaitForSecondsRealtime(spiderStartTime);
            aipath.canMove = true;
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
    IEnumerator waitTimeToDestroy(GameObject other)
    {
        yield return new WaitForSecondsRealtime(.45f);
        restartMenu.SetActive(true);
        Destroy(other);
    }
    public void RestartMenu(GameObject other)
    {
        StartCoroutine(waitTimeToDestroy(other));
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
