using System.Collections;
using System.Collections.Generic;
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

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        blockChanger = GetComponent<BlockChanger>();
        spriteRenderer = ghostObject.GetComponent<SpriteRenderer>();
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
        /*
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = transform.position.z;
            //transform.position = touchPosition;
        }
        */
        moveDirection = playerControls.ReadValue<Vector2>().normalized;

        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);

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
        }
        else
        {
            ghostObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        rb.velocity = new Vector2(moveDirection.x * moveSpeed * Time.deltaTime, moveDirection.y * moveSpeed * Time.deltaTime);
        //rb.velocity = new Vector2(joystick.Horizontal * moveSpeed * Time.deltaTime, joystick.Vertical * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Fridge"))
        {
            player.currentHunger = 100;
        }
        else if (other.CompareTag("Toilet"))
        {
            player.currentBladder = 100;
        }
        else if (other.CompareTag("Shower"))
        {
            player.currentHygiene = 100;
        }
        else if (other.CompareTag("Bed"))
        {
            player.currentSleep = 100;
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
