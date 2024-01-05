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

    void Start()
    {
        transform.position = spawnpoint.position;
    }
    void Update()
    {
        if (isPlayer1)
        {
            movement.x = Input.GetAxisRaw("HorizontalWASD");
            movement.y = Input.GetAxisRaw("VerticalWASD");
        }
        if (!isPlayer1)
        {
            movement.x = Input.GetAxisRaw("HorizontalArrows");
            movement.y = Input.GetAxisRaw("VerticalArrows");
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }
}
