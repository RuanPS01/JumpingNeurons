using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class PlayerCameraMoveController : MonoBehaviour
{
    [SerializeField]
    Transform cameraPosition;

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
