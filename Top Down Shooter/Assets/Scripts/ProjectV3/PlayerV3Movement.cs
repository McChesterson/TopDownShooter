using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

    public Quaternion playerDirection = Quaternion.identity;
    bool rotateMode = false;
    public float zRot = 0;

    void Start()
    {
        transform.position = spawnpoint.position;
    }
    void Update()
    {
        //rb.rotation = 0;
        rb.angularVelocity = 0;
        if (Input.GetKeyDown(isPlayer1? KeyCode.LeftShift : KeyCode.RightShift) && !rotateMode)
        {
            rotateMode = true;
            //Debug.Log(gameObject.name + " rotateMode = " + rotateMode);
        }
        else if (Input.GetKeyDown(isPlayer1 ? KeyCode.LeftShift : KeyCode.RightShift))
        {
            rotateMode = false;
            //Debug.Log(gameObject.name + " rotateMode = " + rotateMode);
        }
        //when in rotate mode
        if (rotateMode)
        {
            zRot = Input.GetAxisRaw(isPlayer1 ? "HorizontalWASD" : "HorizontalArrows") * -rotateSpeed * Time.deltaTime;
            if(Input.GetAxisRaw(isPlayer1 ? "HorizontalWASD" : "HorizontalArrows") != 0) 
            { 
                transform.Rotate(0, 0, zRot);
                playerDirection = transform.rotation;
            }
        }
        //when NOT in rotate mode
        else
        {
            //moving the player regularly
            movement.x = Input.GetAxisRaw(isPlayer1? "HorizontalWASD" : "HorizontalArrows");
            movement.y = Input.GetAxisRaw(isPlayer1? "VerticalWASD" : "VerticalArrows");
            movement = movement.normalized;
        }
    }
    private void FixedUpdate()
    {
        if(!rotateMode)
            rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }
}
