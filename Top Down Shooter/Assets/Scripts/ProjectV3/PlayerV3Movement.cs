using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV3Movement : MonoBehaviour
{
    public bool isPlayer1;
    [Space]
    public Rigidbody2D rb;
    [SerializeField] CircleCollider2D circleCol;
    [SerializeField] Transform spawnpoint;
    [Space]
    [SerializeField] Vector2 movement;
    public float playerSpeed;
    public float rotateSpeed = 5;

    Quaternion playerDirection = Quaternion.identity;
    bool rotateMode = false;

    void Start()
    {
        transform.position = spawnpoint.position;
    }
    void Update()
    {
        //rb.rotation = 0;
        rb.angularVelocity = 0;
        transform.rotation = playerDirection;
        if (Input.GetKeyDown(isPlayer1? KeyCode.LeftShift : KeyCode.RightShift) && !rotateMode)
        {
            rotateMode = true;
            Debug.Log(gameObject.name + " rotateMode = " + rotateMode);
        }
        else if (Input.GetKeyDown(isPlayer1 ? KeyCode.LeftShift : KeyCode.RightShift))
        {
            rotateMode = false;
            Debug.Log(gameObject.name + " rotateMode = " + rotateMode);
        }
        if (rotateMode)
        {
            //rotating the player
            float zRot;
            zRot = transform.rotation.z;
            transform.Rotate(0, 0, zRot -= Input.GetAxisRaw(isPlayer1? "HorizontalWASD" : "HorizontalArrows") * rotateSpeed);
            Debug.Log(zRot);
            return;
        }
        else
        {
            //moving the player regularly
            movement.x = Input.GetAxisRaw(isPlayer1? "HorizontalWASD" : "HorizontalArrows");
            movement.y = Input.GetAxisRaw(isPlayer1? "VerticalWASD" : "VerticalArrows");
            movement = movement.normalized;
        }
        /*
        //all of the controls for Player1
        if (isPlayer1)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !rotateMode)
            {
                rotateMode = true;
                Debug.Log("Player1's rotateMode = " + rotateMode);
                //transform.Rotate(0, 0, rotateSpeed);
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                rotateMode = false;
                Debug.Log("Player1's rotateMode = " + rotateMode);
            }
            
        }
        //all of the controls for Player2
        else
        {
            if (Input.GetKeyDown(KeyCode.RightShift) && !rotateMode)
            {
                rotateMode = true;
                Debug.Log("Player2's rotateMode = " + rotateMode);
                //transform.Rotate(0, 0, rotateSpeed);
            }
            else if (Input.GetKeyDown(KeyCode.RightShift))
            {
                rotateMode = false;
                Debug.Log("Player2's rotateMode = " + rotateMode);
            }
            movement.x = Input.GetAxisRaw("HorizontalArrows");
            movement.y = Input.GetAxisRaw("VerticalArrows");
            movement = movement.normalized;
        }
        */
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }
}
