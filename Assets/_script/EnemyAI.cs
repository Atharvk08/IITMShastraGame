using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public float speed = 10f;
    public float nextWaypointDistance=1f;
    [SerializeField] bool canMove;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    bool enemyCanMove = false;
    bool playerDetected;
    public PlayerScript playerScript;
    Seeker seeker;
    Rigidbody2D rb;

    Vector2 direction;
    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);

        playerDetected = false;
        
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
            Debug.Log("Path updated");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerTorchLight"))
        {
            playerDetected = true;
        }
    }

    private void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        //enemy will move if torch is lit and player is detected
        canMove = playerScript.getTorchEnabled() && playerDetected;
        if (canMove)
        {
            MoveEnemy();
            Debug.Log(canMove);
        }
    }

    void MoveEnemy()
    {
        direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
