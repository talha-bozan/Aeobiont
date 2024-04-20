using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;

public class CharacterController2D : MonoBehaviour
{

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private int dashCooldownLength = 100;

    [Header("Component References")]
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveDirection = Vector2.zero;

    [Header("Input Settings")]
    [SerializeField] private InputAction playerControls;
    private bool canDash = true;
    private int dashTimer;

    [Header("UI Elements")]
    [SerializeField] private GameObject hotbar;
    [SerializeField] private BlockChanger blockChanger;
    [SerializeField] private GameObject ghostObject;
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    [Header("Platform Specific")]
    [SerializeField] private GameObject joystickGameObject;
    [SerializeField] private Joystick joystick;
    private Gem gem;


    [Space(10)]
    
    [SerializeField]
    private NeedManager needManager; // for needs
    [Space(10)]

    [SerializeField]
    private SavePrefs saveprefs;

    [SerializeField]
    private LayerMask farmMask;
    private Collider2D farmCol;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        blockChanger = GetComponent<BlockChanger>();
        gem = GetComponent<Gem>();
        spriteRenderer = ghostObject.GetComponent<SpriteRenderer>();
        playerControls.Enable();
    }

    void Start()
    {
#if UNITY_ANDROID || UNITY_IOS
        joystickGameObject.SetActive(true);
#else
        joystickGameObject.SetActive(false);
#endif
        saveprefs.LoadGame();
        needManager.difficultyLevel = saveprefs.difficultyLevel;
    }

    void Update()
    {
        if (blockChanger != null)
        {
            int hotbarIndex = Mathf.Clamp(blockChanger.GetCurrentHotbarIndex(), 0, sprites.Length - 1);
            // Now you can use hotbarIndex safely here.
        }
        else
        {
            Debug.LogError("BlockChanger reference not set in the inspector!");
        }
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            moveDirection = Vector2.zero;
            UpdateAnimations();
            return;
        }

        HandleInput();
        UpdateAnimations();
        UpdateGhostObject();
               

        Vector2 playerLocation = new Vector2(transform.position.x, transform.position.y);

        farmCol = Physics2D.OverlapCircle(playerLocation, 0.2f, farmMask);
        if (farmCol != null)
        {
            gem.changeBalance(0.05f);
        }
    }

    void FixedUpdate()
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            ProcessMovement();
            HandleDash();
        }
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
        rb.velocity = moveDirection * moveSpeed * Time.fixedDeltaTime;
    }

      private void UpdateGhostObject()
    {
        if (hotbar.activeInHierarchy)
        {
            int hotbarIndex = Mathf.Clamp(blockChanger.GetCurrentHotbarIndex(), 0, sprites.Length - 1);
            spriteRenderer.sprite = sprites[hotbarIndex];

            Vector3 mousePos = Mouse.current.position.ReadValue();
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePos);
            worldPoint.x = Mathf.Floor(worldPoint.x) + 0.5f;
            worldPoint.y = Mathf.Floor(worldPoint.y) + 0.5f;
            ghostObject.transform.position = new Vector3(worldPoint.x, worldPoint.y, 0);
            ghostObject.SetActive(true);
        }
        else
        {
            ghostObject.SetActive(false);
        }
    }

    private void HandleDash()
    {
        if (!canDash)
        {
            dashTimer--;
            if (dashTimer <= 0)
            {
                canDash = true;
            }
        }
        else if (canDash && moveDirection != Vector2.zero && Keyboard.current.shiftKey.isPressed)
        {
            Vector2 dashForce = moveDirection.normalized * dashSpeed;
            rb.AddForce(dashForce, ForceMode2D.Impulse);
            canDash = false;
            dashTimer = dashCooldownLength;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Fridge"))
        {
            if(gem.getBalance() >= 20)
            {
                SoundManager.playSound("fridge_open");
                gem.changeBalance(-20);
                needManager.InterpolateNeed(NeedManager.NeedType.hunger, 0.7f);
            }
            else
            {
                Debug.Log("You don't have enough money to eat; you should go to the farm.");
            }
        }
        else if (other.CompareTag("Toilet"))
        {
            SoundManager.playSound("toilet_flush");
            needManager.ResetNeed(NeedManager.NeedType.bladder);
        }
        else if (other.CompareTag("Shower"))
        {
            SoundManager.playSound("sink_wash");
            needManager.InterpolateNeed(NeedManager.NeedType.hygiene, 0.7f);
        }
        else if (other.CompareTag("Bed"))
        {
            needManager.ResetNeed(NeedManager.NeedType.sleep);

        }
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

}
