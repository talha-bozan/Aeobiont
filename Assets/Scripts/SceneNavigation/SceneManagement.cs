using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private Canvas firstScreen;
    [SerializeField] private Canvas customizeScreen;

    public void ChangeCanvasToCustomize()
    {
        firstScreen.gameObject.SetActive(false);
        customizeScreen.gameObject.SetActive(true);
    }

}
