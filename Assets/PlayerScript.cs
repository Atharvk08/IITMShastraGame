using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float distanceToMove;
    [SerializeField] private float moveSpeed;
    public Collider2D moveUp, moveDown, moveRight, moveLeft,wall;

    [SerializeField] private GameObject torch;
    [SerializeField] private GameObject camera;
    enum Direction { centre, up,right ,down ,left};

    Direction torchDirection;
    private bool moveToPoint = false;
    private Vector3 endPosition;
    void Start()
    {
        endPosition = transform.position;

        torch.SetActive(true);
        torchDirection = Direction.centre;

        camera = GameObject.Find("Main Camera");
    }

    void FixedUpdate()
    {
        if (moveToPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !moveLeft.IsTouching(wall)) //Left
        {
            Debug.Log("left coll" + moveLeft.IsTouching(wall));
            endPosition = new Vector3(endPosition.x - distanceToMove, endPosition.y, endPosition.z);
            moveToPoint = true;
        }
        if (Input.GetKeyDown(KeyCode.D) && !moveRight.IsTouching(wall)) //Right
        {
            endPosition = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
            moveToPoint = true;
        }
        if (Input.GetKeyDown(KeyCode.W)  )//Up
        {
            endPosition = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);
            moveToPoint = true;
        }
        if (Input.GetKeyDown(KeyCode.S)) //Down
        {
            endPosition = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
            moveToPoint = true;
        }
    }
}
