using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    [SerializeField]
    private Joystick joystick;

    private Collider2D lastCollider; // Cache the last checked collider

    private void Awake()
    {
        spriteRenderer = ghostObject.GetComponent<SpriteRenderer>();
        blockChanger = GetComponent<BlockChanger>();
    }

    private void Update()
    {
        if (blockChanger == null)
        {
            Debug.LogError("BlockChanger reference not set in the inspector!");
            return;
        }

        int hotbarIndex = Mathf.Clamp(blockChanger.GetCurrentHotbarIndex(), 0, sprites.Length - 1);

        UpdateGhostObject(hotbarIndex);

#if UNITY_ANDROID || UNITY_IOS
        HandleTouchInput();
#else
        HandleMouseInput();
#endif
    }



    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            // Check if joystick input is active
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                return;
            }

            // Get the first touch position
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f; // Ensure it's in the 2D plane

            // Raycast to find the object at the touch position
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, 0.1f, mask); // Zero vector for precise check

            if (hit.collider != null)
            {
                GridCell plotGrid = hit.collider.GetComponent<GridCell>();
                if (plotGrid != null)
                {
                    if (objectToPlace == null)
                        plotGrid.deleteObject(); // Delete object if objectToPlace is null
                    else
                        plotGrid.placeObject(objectToPlace); // Place object otherwise
                }
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

        // Use Raycast to find the first object hit
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0.1f, mask); // Zero vector to raycast to the exact point

        if (hit.collider != null)
        {
            GridCell plotGrid = hit.collider.GetComponent<GridCell>();
            if (plotGrid != null)
            {
                if (objectToPlace == null)
                    plotGrid.deleteObject();
                else
                    plotGrid.placeObject(objectToPlace);
            }
        }
    }
}


private void UpdateGhostObject(int hotbarIndex)
    {
        if (hotbar.activeInHierarchy)
        {
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the trigger area
        if (other.CompareTag("Home"))
        {
            hotbar.SetActive(true);
            plotSign.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(gameObject != null)
        {
            // Check if the collider belongs to the trigger area
            if (other.CompareTag("Home"))
            {
                hotbar.SetActive(false);
                plotSign.SetActive(false);
            }
        }
    }
}
