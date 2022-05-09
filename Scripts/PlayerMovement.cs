using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Vector2 moveInput;
    private float movementX;
    private float movementY;

    [Space(10)]
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private int dashCooldownLength;
    private int dashTimer;
    private bool canDash = true;

    [Space(10)]
    [SerializeField]
    private GameObject myPrefab;

    [SerializeField]
    public Collider2D theCollider;

    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTimer = dashCooldownLength;
    }

    void Update()
    {
        rb.velocity = rb.velocity * 0.99f;
        rb.AddForce(moveInput * moveSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (!canDash)
        {
            if (dashTimer <= 0)
                canDash = true;
            else
                dashTimer--;
        }
        
        Vector2 movement = new Vector2(movementX, movementY);

        rb.AddForce(movement * moveSpeed);
    }

    void OnDash(InputValue dashValue) 
    {
        if (canDash)
        {
            Vector2 vel = rb.velocity;

            if (Math.Abs(vel.x) >= Math.Abs(vel.y))
            {
                if (vel.x > 0)
                { rb.AddForce(new Vector2(dashSpeed, 0)); }
                else
                { rb.AddForce(new Vector2(-dashSpeed, 0)); }
            }
            else
            {
                if (vel.y > 0)
                { rb.AddForce(new Vector2(0, dashSpeed)); }
                else
                { rb.AddForce(new Vector2(0, -dashSpeed)); }
            }
            canDash = false;
            dashTimer = dashCooldownLength;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
