using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cysharp.Threading.Tasks; 
using DG.Tweening;

public class CharacterController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    private float _moveSpeed = 100f; 
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

    [Header("Component References")]
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveDirection = Vector2.zero;

    [Header("Input Settings")]
    [SerializeField] private InputAction playerControls;
    private bool canDash = true;

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
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            moveDirection = Vector2.zero;
            return;
        }
        HandleInput();
        UpdateAnimations();
    }

    void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            moveDirection = Vector2.zero;
            return;
        }
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
        DOTween.Kill(rb);

        Vector2 targetPosition = rb.position + (moveDirection * _moveSpeed * Time.fixedDeltaTime);

        rb.DOMove(targetPosition, 0.2f).SetEase(Ease.Linear);
    }

    private async void HandleDash()
    {
        if (canDash && moveDirection != Vector2.zero && Keyboard.current.shiftKey.isPressed)
        {
            Vector2 dashForce = moveDirection.normalized * _dashSpeed;

            rb.DOMove(rb.position + dashForce, 0.1f) 
               .SetEase(Ease.InOutQuad);

            canDash = false;

            await StartDashCooldown(); 
        }
    }

    private async UniTask StartDashCooldown()
    {
        await UniTask.Delay(3000); 
        canDash = true;
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
