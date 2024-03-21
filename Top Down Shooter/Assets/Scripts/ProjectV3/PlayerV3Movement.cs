using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerV3Movement : MonoBehaviour
{
    public P1Controls controls;
    public bool isPlayer1;
    [Space]
    
    public Rigidbody2D rb;
    [SerializeField] CircleCollider2D circleCol;
    [SerializeField] Transform spawnpoint;
    [Space]

    public Vector2 movement;
    public float playerSpeed;
    public float rotateSpeed = 5;
    float deadzone = 0.2f;

    public Quaternion playerDirection = Quaternion.identity;
    //bool rotateMode = false;
    public float zRot = 0;
    public Vector2 direction;
    private void Awake()
    {
        controls = new P1Controls();

        controls.PlayerMovement.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();

        //controls.PlayerMovement.Rotate.performed += ctx => zRot = ctx.ReadValue<float>();
        //controls.PlayerMovement.Rotate.canceled += ctx => zRot = 0;
    }
    void OnEnable()
    {
        controls.PlayerMovement.Enable();
    }
    private void OnDisable()
    {
        controls.PlayerMovement.Disable();
    }
    void Start()
    {
        transform.position = spawnpoint.position;
    }
    void Update()
    {
        /*
            //rb.rotation = 0;
            rb.angularVelocity = 0;
            if (Input.GetKeyDown(isPlayer1 ? KeyCode.LeftShift : KeyCode.RightShift) && !rotateMode)
            {
                rotateMode = true;
            }
            else if (Input.GetKeyDown(isPlayer1 ? KeyCode.LeftShift : KeyCode.RightShift))
            {
                rotateMode = false;
            }
            //when in rotate mode
            if (rotateMode)
            {
                zRot = Input.GetAxisRaw(isPlayer1 ? "HorizontalWASD" : "HorizontalArrows") * -rotateSpeed * Time.deltaTime;
                if (Input.GetAxisRaw(isPlayer1 ? "HorizontalWASD" : "HorizontalArrows") != 0)
                {
                    transform.Rotate(0, 0, zRot);
                    playerDirection = transform.rotation;
                }
            }
            //when NOT in rotate mode
            else
            {
                movement.x = Input.GetAxisRaw(isPlayer1 ? "HorizontalWASD" : "HorizontalArrows");
                movement.y = Input.GetAxisRaw(isPlayer1 ? "VerticalWASD" : "VerticalArrows");
                movement = movement.normalized;
        }
        */
        //rb.MovePosition(rb.position + movement * playerSpeed * Time.deltaTime);
        if (math.abs(movement.x) < deadzone && math.abs(movement.y) < deadzone)
        {
            return;
        }
        else
        {
            transform.Translate(new Vector2(movement.x, movement.y) * playerSpeed * Time.deltaTime);
        }
        //transform.eulerAngles = direction;
        //transform.rotation = Quaternion.Euler(0, 0, zRot);
        //Debug.Log(zRot);

    }
    private void FixedUpdate()
    {
        //if(!rotateMode)
          //  rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }
}
