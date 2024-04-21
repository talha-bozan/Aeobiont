using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class CharacterController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    private float _moveSpeed = 100f; // Reduced speed
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }
    private float _dashSpeed = 200f;
    public float DashSpeed
    {
        get { return _dashSpeed; }
        set { _dashSpeed = value; }
    }
    [SerializeField] private int dashCooldownLength = 100;

    [Header("Component References")]
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveDirection = Vector2.zero;

    [Header("Input Settings")]
    [SerializeField] private InputAction playerControls;
    private bool canDash = true;
    private int dashTimer;

    [Header("Platform Specific")]
    [SerializeField] private GameObject joystickGameObject;
    [SerializeField] private Joystick joystick;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        playerControls.Enable();
    }

    void Start()
    {
#if UNITY_ANDROID || UNITY_IOS
        joystickGameObject.SetActive(true);
#else
        joystickGameObject.SetActive(false);
#endif
    }

    void Update()
    {
        HandleInput();
        UpdateAnimations();
    }

    void FixedUpdate()
    {
        ProcessMovement();
        HandleDash();
    }

    private void HandleInput()
    {
#if UNITY_ANDROID || UNITY_IOS
        moveDirection = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;
#else
        moveDirection = playerControls.ReadValue<Vector2>().normalized;
#endif
    }

    private void UpdateAnimations()
    {
        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);
    }

    private void ProcessMovement()
    {
        // Clear any existing DOTween movement to prevent interruptions
        

        // Calculate the target position
        Vector2 targetPosition = rb.position + (moveDirection * _moveSpeed * Time.fixedDeltaTime);

        // Smoothly tween to the target position with a slight easing
        rb.DOMove(targetPosition, 0.2f).SetEase(Ease.Linear);
    }

    private void HandleDash()
    {
        if (canDash && moveDirection != Vector2.zero && Keyboard.current.shiftKey.isPressed)
        {
            Vector2 dashForce = moveDirection.normalized * _dashSpeed;


            rb.DOMove(rb.position + dashForce, 0.1f) // Short dash with easing
               .SetEase(Ease.InOutQuad);

            canDash = false;
            dashTimer = dashCooldownLength;
        }

        if (!canDash)
        {
            dashTimer--;
            if (dashTimer <= 0)
            {
                canDash = true;
            }
        }
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
