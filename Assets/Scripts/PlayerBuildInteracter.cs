using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerBuildInteracter : MonoBehaviour
{
    public GameObject objectToPlace;
    [SerializeField]
    private LayerMask mask = default;
    [SerializeField]
    private GameObject hotbar;
    [SerializeField]
    private GameObject plotSign;
    [SerializeField] private GameObject ghostObject;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private BlockChanger blockChanger;
    [SerializeField] private Sprite[] sprites;

    public Collider2D theCollider;

    [SerializeField]
    private Joystick joystick;

    private void Awake()
    {
        spriteRenderer = ghostObject.GetComponent<SpriteRenderer>();
        blockChanger = GetComponent<BlockChanger>();

    }

    private void Update()
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
        HandleHotbarAndPlotSign();
        UpdateGhostObject();
#if UNITY_ANDROID || UNITY_IOS
        HandleTouchInput();
#else
        HandleMouseInput();
#endif
    }

    private void HandleHotbarAndPlotSign()
    {
        Vector2 playerLocation = new Vector2(transform.position.x, transform.position.y);
        theCollider = Physics2D.OverlapCircle(playerLocation, 1.0f, mask);

        if (theCollider != null)
        {
           hotbar.SetActive(true);
           plotSign.SetActive(true);
        }
        else
        {
            hotbar.SetActive(false);
            plotSign.SetActive(false);
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                return;
            }

            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;

            Vector2 nearestGrid = new Vector2(touchPosition.x, touchPosition.y);

            theCollider = Physics2D.OverlapCircle(nearestGrid, 0.0f, mask);

            if (theCollider != null)
            {
                GridCell plotGrid = theCollider.GetComponent<GridCell>();
                if (objectToPlace == null)
                    plotGrid.deleteObject();
                else
                    plotGrid.placeObject(objectToPlace);
            }
        }
    }

    private void HandleMouseInput()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePosition.z = 0f;

            Vector2 nearestGrid = new Vector2(mousePosition.x, mousePosition.y);

            theCollider = Physics2D.OverlapCircle(nearestGrid, 0.0f, mask);

            if (theCollider != null)
            {
                GridCell plotGrid = theCollider.GetComponent<GridCell>();
                if (objectToPlace == null)
                    plotGrid.deleteObject();
                else
                    plotGrid.placeObject(objectToPlace);
            }
        }
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
}
