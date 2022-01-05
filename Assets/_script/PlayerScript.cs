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
    private Direction torchDirection;
    [SerializeField]private GameObject torchLight;
    private bool torchEnabled;

    public bool getTorchEnabled() { return torchEnabled; }
    public void setTorchEnabled(bool flag) { torchEnabled=flag; }

    public GameObject camera;
    private Vector3 cameraOffset;

    enum Direction { centre, up,right ,down ,left};
    private Vector3 playerDirection;

    
    private bool moveToPoint = false;
    private Vector3 endPosition;

    private Animator anim;
    [SerializeField] private Animator fireAnimator;
    //tilemaps
    [SerializeField] private Tilemap groundTimeMap;
    [SerializeField] private Tilemap wallTileMap;


    [SerializeField] private GameObject laternGFX;
    [SerializeField] private float laternDistance = 1f;

    [SerializeField] private GameObject fireComponent;
    void Start()
    {
        endPosition = transform.position;

        torch.SetActive(true);
        torchDirection = Direction.centre;

        camera = GameObject.Find("Main Camera");
        cameraOffset.z = camera.transform.position.z;

        Debug.Log("torch direction : " + torchDirection);
        torchEnabled = true;

        anim = GetComponent<Animator>();
        fireAnimator.SetBool("burning", true);
    }


    private void LateUpdate()
    {
        if (moveToPoint && canMove(playerDirection))
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, endPosition + cameraOffset, cameraMoveSpeed * Time.deltaTime);
        }
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        playerMove();
        torchActive();
    }
    

    private void torchActive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            torch.SetActive(!torch.activeSelf);
            torchEnabled = torch.activeSelf;
            Debug.Log("troch active status:" + torchEnabled);
            if (!torch.activeSelf)
            {
                fireComponent.SetActive(false);
            }

            if (torchEnabled)
            {
                fireComponent.SetActive(true);
                torchDirection = Direction.centre;
                torchLight.transform.localPosition = new Vector3(0f, 0f, 0f);
                fireAnimator.Play("FireLit");
                laternGFX.transform.localPosition = new Vector3(0f, 0f, 0f);
            }
        }
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
                    if (torchDirection != Direction.left)//torch not pointing in left direction
                    {
                        torchDirection = Direction.left;
                        torchLight.transform.localPosition = new Vector3(-distanceToMove,0f,0f);
                        laternGFX.transform.localPosition = new Vector3(-laternDistance, 0f, 0f);
                    }//player moving in left direction
                    else if(torchDirection==Direction.left || torchEnabled)
                    {
                        endPosition = playerDirection;
                        moveToPoint = true;
                    }
                    anim.SetBool("left", true);
                    anim.SetBool("up", false);
                    anim.SetBool("down", false);
                    anim.SetBool("right", false);
                }
            }
            if (Input.GetKeyDown(KeyCode.D)) //Right
            {
                playerDirection = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
                if (canMove(playerDirection))
                {
                    if (torchDirection != Direction.right)//torch not pointing in right direction
                    {
                        torchDirection = Direction.right;
                        torchLight.transform.localPosition = new Vector3(distanceToMove, 0f, 0f);
                        laternGFX.transform.localPosition = new Vector3(laternDistance, 0f, 0f);
                    }
                    else if (torchDirection == Direction.right || torchEnabled)//player moving in rigth direction
                    {
                        endPosition = playerDirection;
                        moveToPoint = true;
                    }
                    anim.SetBool("left", false);
                    anim.SetBool("up", false);
                    anim.SetBool("down", false);
                    anim.SetBool("right", true);
                }
            }
            if (Input.GetKeyDown(KeyCode.W))//Up
            {
                playerDirection = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);
                if (canMove(playerDirection))
                {
                    if (torchDirection != Direction.up)
                    {
                        torchDirection = Direction.up;
                        torchLight.transform.localPosition = new Vector3(0f,distanceToMove,  0f);
                        laternGFX.transform.localPosition = new Vector3(0f,0f,  0f);
                    }
                    else if (torchDirection == Direction.up || torchEnabled)
                    {
                        endPosition = playerDirection;
                        moveToPoint = true;
                    }
                    anim.SetBool("left", false);
                    anim.SetBool("up", true);
                    anim.SetBool("down", false);
                    anim.SetBool("right", false);
                }
            }
            if (Input.GetKeyDown(KeyCode.S)) //Down
            {
                playerDirection = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
                if (canMove(playerDirection))
                {
                    if (torchDirection != Direction.down)
                    {
                        torchDirection = Direction.down;
                        torchLight.transform.localPosition = new Vector3(0f, -distanceToMove, 0f);
                        laternGFX.transform.localPosition = new Vector3(0f,-laternDistance, 0f);
                    }
                    else if (torchDirection == Direction.down || torchEnabled)
                    {
                        endPosition = playerDirection;
                        moveToPoint = true;
                    }
                    anim.SetBool("left", false);
                    anim.SetBool("up", false);
                    anim.SetBool("down", true);
                    anim.SetBool("right", false);
                }
            }


        }
    }
}
