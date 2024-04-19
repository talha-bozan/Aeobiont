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

    [Space(10)]
    public Collider2D theCollider;

    [SerializeField]
    private Joystick joystick;

    private void Update()
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

        if (Input.touchCount > 0)
        {
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                return;
            }

            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            //transform.position = touchPosition;

            Vector2 nearestGrid = new Vector2(touchPosition.x, touchPosition.y);

            #region Old Code
            /* Not the "Basic Grid Placement" we want */
            //worldPoint.x = ((worldPoint.x * 10f) - (worldPoint.x * 10f) % 1) * 0.1f;
            //worldPoint.y = ((worldPoint.y * 10f) - (worldPoint.y * 10f) % 1) * 0.1f;
            //worldPoint.x = worldPoint.x - worldPoint.x % 1;
            //worldPoint.y = worldPoint.y - worldPoint.y % 1;
            //Vector2 pos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
            //print("Pos:" + pos.ToString());endre
            #endregion

            theCollider = Physics2D.OverlapCircle(nearestGrid, 0.0f, mask);

            if (theCollider != null)
            {
                //print("\tColliders: " + theCollider);

                GridCell plotGrid = theCollider.GetComponent<GridCell>();
                if (objectToPlace == null)
                    plotGrid.deleteObject();
                plotGrid.placeObject(objectToPlace);
            }

        }
    }

    void OnMouseClick(InputValue clickValue)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            //transform.position = touchPosition;

            Vector2 nearestGrid = new Vector2(touchPosition.x, touchPosition.y);

            Debug.DrawLine(Vector3.zero, touchPosition);
            print("This->" + touch.position);

            #region Old Code
            /* Not the "Basic Grid Placement" we want */
            //worldPoint.x = ((worldPoint.x * 10f) - (worldPoint.x * 10f) % 1) * 0.1f;
            //worldPoint.y = ((worldPoint.y * 10f) - (worldPoint.y * 10f) % 1) * 0.1f;
            //worldPoint.x = worldPoint.x - worldPoint.x % 1;
            //worldPoint.y = worldPoint.y - worldPoint.y % 1;
            //Vector2 pos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
            //print("Pos:" + pos.ToString());endre
            #endregion

            theCollider = Physics2D.OverlapCircle(nearestGrid, 0.0f, mask);

            if (theCollider != null)
            {
                //print("\tColliders: " + theCollider);

                GridCell plotGrid = theCollider.GetComponent<GridCell>();
                if (objectToPlace == null)
                    plotGrid.deleteObject();
                plotGrid.placeObject(objectToPlace);
            }

        }

        /*
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.farClipPlane * .5f;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePos);
        worldPoint.z = 0f;
        */

        //print("WorldPoint:" + worldPoint);

        


    }
}
