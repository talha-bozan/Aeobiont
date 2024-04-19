using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject[] blockTypes; // Holds the prefab GameObjects that can be placed.

    [SerializeField]
    private PlayerBuildInteracter placeOfObjectToPlace; // Reference to the component that handles object placement.

    public int currentHotbarIndex; // Index of the currently selected item in the hotbar.

    // Start is called before the first frame update
    void Start()
    {
        placeOfObjectToPlace = GetComponent<PlayerBuildInteracter>();
    }

    // This method is called to change the currently selected hotbar item.
    public void OnHotbarClick(int hotbarIndex)
    {
        if (hotbarIndex < 0 || hotbarIndex >= blockTypes.Length) // Check if the index is within valid range.
            return;

        currentHotbarIndex = hotbarIndex;
        placeOfObjectToPlace.objectToPlace = blockTypes[hotbarIndex];

        // If the index is 4, set the object to place to null, possibly for a 'delete' or 'empty' function.
        if (hotbarIndex == 4)
            placeOfObjectToPlace.objectToPlace = null;
    }

    // This method provides safe access to the currentHotbarIndex.
    public int GetCurrentHotbarIndex()
    {
        return currentHotbarIndex;
    }
}
