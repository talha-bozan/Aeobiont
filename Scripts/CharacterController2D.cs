using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private InputAction playerControls;

    private Rigidbody2D rb;
    private Animator anim;
    private Gem gem;

    [Space(10)]
    [SerializeField]
    private GameObject hotbar;
    [SerializeField]
    private GameObject ghostObject;
    private SpriteRenderer spriteRenderer;
    private BlockChanger blockChanger;
    [SerializeField]
    private Sprite[] sprites;

    private Vector2 moveDirection = Vector2.zero;

    [SerializeField]
    private Player player; // for needs

    [SerializeField]
    private Joystick joystick;

    [Space(10)]
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private int dashCooldownLength;
    private int dashTimer;
    private bool canDash = true;

    [SerializeField]
    private SavePrefs saveprefs;

    [SerializeField]
    private LayerMask farmMask = default;
    private Collider2D farmCol;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        blockChanger = GetComponent<BlockChanger>();
        gem = GetComponent<Gem>();
        spriteRenderer = ghostObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        saveprefs.LoadGame();
        player.difficultyLevel = saveprefs.difficultyLevel;
    }

    void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            moveDirection = Vector2.zero;
            anim.SetFloat("Horizontal", moveDirection.x);
            anim.SetFloat("Vertical", moveDirection.y);
            return;
        }
        

        moveDirection = playerControls.ReadValue<Vector2>().normalized;

        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = transform.position.z;
            //transform.position = touchPosition;
            anim.SetFloat("Horizontal", joystick.Horizontal);
            anim.SetFloat("Vertical", joystick.Vertical);
        }

        if (hotbar.activeInHierarchy)
        {
            spriteRenderer.sprite = sprites[blockChanger.currentHotbarIndex];

            ghostObject.SetActive(true);

            Vector3 mousePos = Mouse.current.position.ReadValue();
            //mousePos.z = Camera.main.farClipPlane * .5f;
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePos);
            worldPoint.x = worldPoint.x - worldPoint.x % 1 + 0.5f + 0.25f;
            worldPoint.y = worldPoint.y - worldPoint.y % 1 - 0.5f - 0.25f + 1f;
            
            ghostObject.transform.position = new Vector3(worldPoint.x, worldPoint.y, ghostObject.transform.position.z);
            //Debug.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(mousePos));
        }
        else
        {
            ghostObject.SetActive(false);
        }

        Vector2 playerLocation = new Vector2(transform.position.x, transform.position.y);


        farmCol = Physics2D.OverlapCircle(playerLocation, 0.2f, farmMask);

        if (farmCol != null)
        {
            gem.changeBalance(0.05f);
        }
    }

    void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (!canDash)
        {
            if (dashTimer <= 0)
                canDash = true;
            else
                dashTimer--;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerDash();
        }
        //rb.velocity = new Vector2(moveDirection.x * moveSpeed * Time.deltaTime, moveDirection.y * moveSpeed * Time.deltaTime);
        rb.velocity = new Vector2(joystick.Horizontal * moveSpeed * Time.deltaTime, joystick.Vertical * moveSpeed * Time.deltaTime);
    }

    void playerDash()
    {
        if (canDash)
        {
            Vector2 vel = rb.velocity;

            if (vel.x == 0f && vel.y == 0f)
            {
                print("Player not moving.");
            }
            else if (Math.Abs(vel.x) >= Math.Abs(vel.y))
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Fridge"))
        {
            if(gem.getBalance() >= 20)
            {
                SoundManager.playSound("fridge_open");
                gem.changeBalance(-20);
                player.currentHunger = Mathf.Lerp(player.currentHunger, player.maxHunger, 0.7f);
            }
            else
            {
                Debug.Log("You don't have enough money to eat; you should go to the farm.");
            }
        }
        else if (other.CompareTag("Toilet"))
        {
            SoundManager.playSound("toilet_flush");
            player.currentBladder = player.maxBladder;
        }
        else if (other.CompareTag("Shower"))
        {
            SoundManager.playSound("sink_wash");
            player.currentHygiene = Mathf.Lerp(player.currentHygiene, player.maxHygiene, 0.7f);
        }
        else if (other.CompareTag("Bed"))
        {
            player.currentSleep = player.maxSleep;
        }
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

}
