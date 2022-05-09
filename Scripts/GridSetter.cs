using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSetter : MonoBehaviour
{
    [SerializeField]
    private GameObject gridCell;

    [SerializeField]
    private int rowAmount = 8;
    [SerializeField]
    private int colAmount = 12;

    private float placementOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 gridCellPosition = new Vector3();
        gridCellPosition.z = 0f;

        gridCellPosition.x = transform.position.x;
        gridCellPosition.y = transform.position.y;


        for (int i = 0; i < rowAmount; i++)
        {
            for (int j = 0; j < colAmount; j++)
            {
                var newGridCell = Instantiate(gridCell, gridCellPosition, Quaternion.identity);
                newGridCell.transform.parent = this.transform;
                gridCellPosition.x += placementOffset;
            }
            gridCellPosition.y -= placementOffset;
            gridCellPosition.x = transform.position.x;
        }
    }
}
