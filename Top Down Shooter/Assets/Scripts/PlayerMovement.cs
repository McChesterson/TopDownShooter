using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    public Vector2 movement;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        movement = movement.normalized * walkSpeed * Time.fixedDeltaTime;
        transform.Translate(movement.x, movement.y, 0);
    }
}