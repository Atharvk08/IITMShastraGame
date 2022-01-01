using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float distanceToMove;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float cameraMoveSpeed;

    [SerializeField] private GameObject torch;
    public GameObject camera;
    private Vector3 cameraOffset;
    enum Direction { centre, up,right ,down ,left};
    private Vector3 playerDirection;

    Direction torchDirection;
    private bool moveToPoint = false;
    private Vector3 endPosition;

    //tilemaps
    [SerializeField] private Tilemap groundTimeMap;
    [SerializeField] private Tilemap wallTileMap;

    
    void Start()
    {
        endPosition = transform.position;

        torch.SetActive(true);
        torchDirection = Direction.centre;

        camera = GameObject.Find("Main Camera");
        cameraOffset.z = camera.transform.position.z;

        Debug.Log("wall" + wallTileMap.size);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (moveToPoint && canMove(playerDirection))
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, endPosition + cameraOffset, cameraMoveSpeed * Time.deltaTime);
        }
    }
    void Update()
    {
        playerMove();
    }

    private bool canMove(Vector3 direction)
    {
        Vector3Int gridPosition = groundTimeMap.WorldToCell(direction);
        if (!groundTimeMap.HasTile(gridPosition)|| wallTileMap.HasTile(gridPosition))
            return false;
        return true;
    }
    private void Move()
    {
        if (moveToPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
            if (transform.position.Equals(endPosition))
                moveToPoint = false;
        }
    }
    private void playerMove()
    {
        if (!moveToPoint)
        {
            if (Input.GetKeyDown(KeyCode.A)) //Left
            {
                playerDirection = new Vector3(endPosition.x - distanceToMove, endPosition.y, endPosition.z);
                if (canMove(playerDirection))
                {
                    endPosition = playerDirection;
                    moveToPoint = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.D)) //Right
            {
                playerDirection = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
                if (canMove(playerDirection))
                {
                    endPosition = playerDirection;
                    moveToPoint = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.W))//Up
            {
                playerDirection = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);
                if (canMove(playerDirection))
                {
                    endPosition = playerDirection;
                    moveToPoint = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.S)) //Down
            {
                playerDirection = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
                if (canMove(playerDirection))
                {
                    endPosition = playerDirection;
                    moveToPoint = true;
                }
            }

        }
    }
}
