using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [Space(10)]
    [SerializeField]
    private bool useLerp;

    private Vector3 offset;
    private Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (useLerp)
        {
            newPosition = new Vector3
            {
                x = Mathf.Lerp(transform.position.x, player.transform.position.x + offset.x, 0.5f),
                y = Mathf.Lerp(transform.position.y, player.transform.position.y + offset.y, 0.5f),
                z = transform.position.z
            };

            transform.position = newPosition;
        }
        else
        {
            transform.position = player.transform.position + offset;
        }
    }
}
