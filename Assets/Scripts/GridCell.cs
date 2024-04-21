using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField]
    private bool isOccupied = false;

    [Space(10)]
    [SerializeField]
    private GameObject currentObject = null;

    private Vector3 gridPlace;

    private void Start()
    {
        gridPlace = GetComponent<Transform>().position;
        gridPlace.z = 0f;
    }
    public Vector3 GetPosition()
    {
        return gridPlace;
    }
    public void placeObject(GameObject objectToPlace)
    {
        if (isOccupied)
            return;
        if (objectToPlace == null)
            return;
        currentObject = objectToPlace;
        
        isOccupied = true;
        var newPlacedObject = Instantiate(currentObject, gridPlace, Quaternion.identity);
        newPlacedObject.transform.parent = this.transform;
    }

    public void deleteObject()
    {
        if (!isOccupied)
            return;
        isOccupied = false;
        Destroy(this.transform.GetChild(1).gameObject);
    }
}
