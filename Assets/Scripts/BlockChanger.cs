using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject[] blockTypes; 

    [SerializeField]
    private PlayerBuildInteracter placeOfObjectToPlace;

    public int currentHotbarIndex;

    void Start()
    {
        placeOfObjectToPlace = GetComponent<PlayerBuildInteracter>();
    }

    public void OnHotbarClick(int hotbarIndex)
    {
        if (hotbarIndex < 0 || hotbarIndex >= blockTypes.Length) 
            return;

        currentHotbarIndex = hotbarIndex;
        placeOfObjectToPlace.objectToPlace = blockTypes[hotbarIndex];

        if (hotbarIndex == 4)
            placeOfObjectToPlace.objectToPlace = null;
    }

    public int GetCurrentHotbarIndex()
    {
        return currentHotbarIndex;
    }
}
